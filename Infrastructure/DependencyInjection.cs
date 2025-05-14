using Domain.Interfaces;
using Domain.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString("Default") ??
                             throw new NullReferenceException("Connection string is null")));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Register repositories (generic repositories)
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

    }
}