using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
    {
        //to do DI
        return services;
    }
}
