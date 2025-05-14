using Application;
using Infrastructure;

namespace Api;

public static class DependencyInjections
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication(configuration);
        // services.AddInfrastructure(configuration);
        services.AddInfrastructure(configuration);
    }
}