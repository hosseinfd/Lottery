using System.Reflection;
using Application.Behaviours;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
                config.AddRequestPreProcessor(typeof(RequestValidationBehavior<>));
            }
        );
        return services;
    }
}