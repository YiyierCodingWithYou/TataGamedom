using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemDetails;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderItemReturnRepository : IGenericRepository<OrderItemReturn>
{
    Task<OrderItemReturn?> GetDetailInckudeOrderItemAsync(int id);
    Task<IReadOnlyList<OrderItemReturn>> GetListIncludeOrderItemAsync();
    Task<int> GetMaxId();
}

