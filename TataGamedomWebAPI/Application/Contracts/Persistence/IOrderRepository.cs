using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<List<OrderWithDeatilsDto>> GetOrderWithDetailsByAccount(string account);
    Task<bool> IsOrderExist(int orderId);
}

