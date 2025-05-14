using System.Reflection;
using Application.Behaviours;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(IApplication))!);
                configuration.AddRequestPreProcessor(typeof(RequestValidationBehavior<>));
            }
        );
    }
}