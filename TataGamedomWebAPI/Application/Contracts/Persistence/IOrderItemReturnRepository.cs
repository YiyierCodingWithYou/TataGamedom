using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemDetails;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnListByOrderId;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderItemReturnRepository : IGenericRepository<OrderItemReturn>
{
    Task<bool> IsReturnOrderExist(int orderItemId);
    Task<OrderItemReturn?> GetDetailIncludeOrderItemAsync(int id);
    Task<IReadOnlyList<OrderItemReturn>> GetListIncludeOrderItemAsync();
    Task<int> GetMaxId();
    Task<List<int>> GetOrderItemIdList(int orderId);
    Task<bool> IsStatusCompletedOrReturned(int orderItemId);
}

