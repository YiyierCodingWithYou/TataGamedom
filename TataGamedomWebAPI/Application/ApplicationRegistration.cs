using System.Reflection;
using TataGamedom.Infrastructure;
using TataGamedomWebAPI.Application.Contracts.PaymentService;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedomWebAPI.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped<IIndexGenerator, IndexGenerator>();
        services.AddScoped<ILinePayService, LinePayService>();

        return services;
    }
}
