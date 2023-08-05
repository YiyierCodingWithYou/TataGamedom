using Microsoft.CodeAnalysis.CSharp.Syntax;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderItemReturnRepository, OrderItemReturnRepository>();
        services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStockInSheetRepository, StockInSheetRepository>();


        return services;
    }
}
