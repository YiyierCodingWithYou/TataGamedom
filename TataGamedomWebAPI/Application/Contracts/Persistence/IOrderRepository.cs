using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<bool> IsOrderExist(int orderId);
}

