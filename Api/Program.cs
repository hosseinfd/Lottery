using Microsoft.AspNetCore;

namespace Api;
 
public class Program
{
    private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

    public static async Task Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        await host.RunAsync();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment) ?? "Local";
        var webHost=  WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                // var env = hostingContext.HostingEnvironment;

                // config.AddJsonFile("appsettings.json", true, true)
                //     .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
               
                config.AddEnvironmentVariables();
            })
            .UseEnvironment(environment)
            .UseStartup<Startup>()
            .ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);
                serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(5);
            });

        // webHost.UseSentry();
        return webHost;
    }
}