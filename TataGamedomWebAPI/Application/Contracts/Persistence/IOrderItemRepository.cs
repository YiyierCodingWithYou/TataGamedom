using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    Task<bool> IsOrderItemExist(int orderItemId);
}

