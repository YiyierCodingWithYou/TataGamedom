using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Infrastructure.Logging;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.ECPayShipmentAdapter;

namespace TataGamedomWebAPI.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
    {
        //Todo Email

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddSignalR();
        services.AddScoped<ECPayShipmentService>();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("https://localhost:3000")
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST")
                        .AllowCredentials();
                });
        });
        return services;
    }
}
