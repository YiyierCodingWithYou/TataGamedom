using Microsoft.CodeAnalysis.CSharp.Syntax;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
    {
        //to do DI
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }
}
