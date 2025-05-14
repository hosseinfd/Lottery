using Api.Middleware;
using Application;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NSwag;
using NSwag.Generation.Processors.Security;
using OpenApiSecurityScheme = Microsoft.OpenApi.Models.OpenApiSecurityScheme;

namespace Api;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
#if DEBUG
        services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));
#endif        
        
        services.AddMvc();
        services.AddDependencies(Configuration);
        services.AddValidatorsFromAssemblyContaining<IApplication>();
        // IdentityModelEventSource.ShowPII = true;
        services.AddHttpContextAccessor();
        services.AddHttpClient();

        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

        
        services.AddOpenApiDocument(options => {
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
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCustomExceptionHandler();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseOpenApi();
        app.UseSwaggerUi();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}