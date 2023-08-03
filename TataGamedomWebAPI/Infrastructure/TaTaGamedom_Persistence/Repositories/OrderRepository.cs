using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsOrderExist(int orderId)
    {
        return await _dbContext.Orders.AnyAsync(o => o.Id == orderId);
    }
}

