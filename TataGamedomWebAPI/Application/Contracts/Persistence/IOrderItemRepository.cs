using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemListByAccount;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    Task<List<OrderItemWithDetailsDto>> GetListByAccountWithDetailsAsync(int orderId);
    Task<bool> IsOrderItemExist(int orderItemId);
}

