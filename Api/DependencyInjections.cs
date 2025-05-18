using Api.Middleware;
using Application;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NSwag;

namespace Api;

public static class DependencyInjections
{
    const string DEV_CORS = "DevCors";
    const string PROD_CORS = "ProdCors";

    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(o =>
            {
                o.AddPolicy(PROD_CORS, builder =>
                    {
                        // builder.AllowAnyOrigin()
                        //     .AllowAnyMethod()
                        //     .AllowAnyHeader();
                    }
                );
                o.AddPolicy(DEV_CORS, builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            }
        );

        services.AddMvc();
        // IdentityModelEventSource.ShowPII = true;
        services.AddHttpContextAccessor();
        services.AddHttpClient();

        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });


        services.AddOpenApiDocument(options =>
        {
            options.PostProcess = document =>
            {
                document.Info = new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Lottery application",
                    // Description = "An ASP.NET Core Web API for managing ToDo items",
                    // TermsOfService = "https://example.com/terms",
                    // Contact = new OpenApiContact
                    // {
                    // Name = "Example Contact",
                    // Url = "https://example.com/contact"
                    // },
                    // License = new OpenApiLicense
                    // {
                    // Name = "Example License",
                    // Url = "https://example.com/license"
                    // }
                };
            };
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static WebApplication ConfigureApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCors(DEV_CORS);
            app.UseOpenApi();
            app.UseSwagger();
            app.UseSwaggerUi();
        }
        else
        {
            app.UseCors(PROD_CORS);
        }

        app.UseCustomExceptionHandler();
        app.UseHttpsRedirection();
        app.UseRouting();


        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        return app;
    }
}