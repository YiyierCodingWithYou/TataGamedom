using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetByIndex(string index);
    Task<string?> GetLinePayTransitionId(int? orderId);
    Task<int> GetMaxId();
    Task<string?> GetOrderIndexById(int orderId);
    Task<List<OrderWithDeatilsDto>> GetOrderWithDetailsByAccount();
    Task<bool> IsOrderExist(int orderId);
    Task UpdateOrderStatusAfterReturn(int orderItemId);
}

