using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemDetails;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderItemReturnRepository : IGenericRepository<OrderItemReturn>
{
    Task<bool> IsReturnOrderExist(int orderItemId);
    Task<OrderItemReturn?> GetDetailInckudeOrderItemAsync(int id);
    Task<IReadOnlyList<OrderItemReturn>> GetListIncludeOrderItemAsync();
    Task<int> GetMaxId();
}

