using System.Net;
using System.Text.Json;
using Domain;
using Domain.Common;
using Domain.Exceptions;

namespace Api.Middleware;

public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private (Result<object>, HttpStatusCode) HandleException(HttpContext context,Exception ex)
        {
            Console.WriteLine("---------------------------Start error-----------------------------");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("---------------------------End error-----------------------------");
            if (ex is ServiceException applicationException)
            {
                return (applicationException.Result, applicationException.StatusCode);
            }

            for (var e = ex.InnerException; e != null; e = e.InnerException)
            {
                if (e is ServiceException)
                {
                    return HandleException(context,e);
                }
            }


            var uuid = Guid.NewGuid();
            var internalException = new InternalException(uuid.ToString(), ex.Message);
            throw internalException;
        }

        private void AddExceptionIntoSentry(HttpContent context)
        {
            var header =
                context.Headers
                    .Where(q => q.Key == "Authorization")
                    .Select(q => q.Value).FirstOrDefault()
                    .FirstOrDefault();

            // if (!string.IsNullOrEmpty(header))
            // {
            //     SentrySdk.WithScope(scope =>
            //     {
            //         scope.SetExtra("JWT Token", header);
            //         SentrySdk.CaptureException(internalException);
            //     });
            // }
            // else
            // {
            //     SentrySdk.CaptureException(internalException);
            // }
        }
        
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (result, code) = HandleException(context,exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonSerializer.Serialize(result,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
