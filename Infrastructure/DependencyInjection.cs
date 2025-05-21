using Domain.Interfaces;
using Domain.RepoInterfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options
                // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseMySQL(configuration.GetConnectionString("Default") ??
                          throw new NullReferenceException("Connection string is null")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Register repositories (generic repositories)
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        return services;
    }
}