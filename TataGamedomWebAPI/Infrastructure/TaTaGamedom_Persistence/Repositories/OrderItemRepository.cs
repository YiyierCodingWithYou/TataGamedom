using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsOrderItemExist(int orderItemId)
    {
        return await _dbContext.OrderItems.AnyAsync(o => o.Id == orderItemId);
    }
}

