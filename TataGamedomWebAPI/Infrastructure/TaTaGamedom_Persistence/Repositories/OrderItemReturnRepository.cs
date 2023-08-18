using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnListByOrderId;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class OrderItemReturnRepository : GenericRepository<OrderItemReturn>, IOrderItemReturnRepository
{
    public OrderItemReturnRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<OrderItemReturn>> GetListIncludeOrderItemAsync()
    {
        List<OrderItemReturn> orderItemReturnList = await _dbContext.OrderItemReturns.Include(o => o.OrderItem).ToListAsync();

        return orderItemReturnList;
    }

    public async Task<OrderItemReturn?> GetDetailIncludeOrderItemAsync(int orderItemId)
    {
        OrderItemReturn? orderItemReturn = await _dbContext.OrderItemReturns.Include(o => o.OrderItem).FirstOrDefaultAsync(o => o.Id == orderItemId);

        return orderItemReturn;
    }

    public async Task<int> GetMaxId()
    {
        return await _dbContext.OrderItemReturns.MaxAsync(o => o.Id);
    }

    public async Task<bool> IsReturnOrderExist(int orderItemId)
    {
        return await _dbContext.OrderItemReturns.AnyAsync(o => o.OrderItemId == orderItemId);
    }

    public async Task<List<int>> GetOrderItemIdList(int orderId)
    {
        return await _dbContext.OrderItemReturns
            .AsNoTracking()
            .Where(r => r.OrderItem.OrderId == orderId)
            .Select(r => r.OrderItemId)
            .ToListAsync();
    }
}

