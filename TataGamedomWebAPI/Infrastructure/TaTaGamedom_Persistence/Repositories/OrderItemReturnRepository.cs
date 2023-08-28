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
        return await GetOrderItemIsReturnedIdList(orderId);
    }

    public async Task<bool> IsStatusCompletedOrReturned(int orderItemId)
    {
        int orderStatusCode =  await _dbContext.OrderItems.Where(oi => oi.Id == orderItemId).Select(oi => oi.Order.OrderStatusId).FirstOrDefaultAsync();
        
        return orderStatusCode == (int)OrderStatus.Completed || 
            orderStatusCode == (int)OrderStatus.ReturnProcessing;
    }

    public async Task<List<OrderItemReturnDto>> GetListByOrderId(int orderId)
    {
        var returnedIdList = await GetOrderItemIsReturnedIdList(orderId);

        var orderItemReturnList = await _dbContext.OrderItemReturns
            .AsNoTracking()
            .Where(r => returnedIdList.Contains(r.OrderItemId))
            .Select(r => new OrderItemReturnDto 
            {
                Id = r.Id,
                OrderItemId = r.OrderItemId,
                Reason = r.Reason,
                IssuedAt = r.IssuedAt,
                CompletedAt = r.CompletedAt,
                IsRefunded = r.IsRefunded,
                IsReturned = r.IsReturned,
                IsResellable = r.IsResellable,
                LinePayRefundTransactionId = r.LinePayRefundTransactionId
            })
            .ToListAsync();

        return orderItemReturnList;
    }

    private async Task<List<int>> GetOrderItemIsReturnedIdList(int orderId)
    {
        return await _dbContext.OrderItemReturns
            .AsNoTracking()
            .Where(r => r.OrderItem.OrderId == orderId)
            .Select(r => r.OrderItemId)
            .ToListAsync();
    }
}

