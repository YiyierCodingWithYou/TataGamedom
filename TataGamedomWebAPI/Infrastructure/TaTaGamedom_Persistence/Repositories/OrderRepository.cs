using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;
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

    public async Task<List<OrderWithDeatilsDto>> GetOrderWithDetailsByAccount(string account)
    {
        var orderWithDeatilsList = await _dbContext.Orders
            .AsNoTracking()
            .Where(o => o.Member.Account == account)
            .Select(o => new OrderWithDeatilsDto
            {
                Id = o.Id,
                GameChiName = o.OrderItems.Select(oi => oi.Product.Game!.ChiName).ToList(),
                ProductIsVirtual = o.OrderItems.Select(oi => oi.Product.IsVirtual).ToList(),
                CreatedAt = o.CreatedAt,
                Total = o.OrderItems.Select(oi => oi.ProductPrice).Sum(),
                OrderStatusCodeName = o.OrderStatus.Name,
            })
            .ToListAsync();

        return orderWithDeatilsList;
    }
}

