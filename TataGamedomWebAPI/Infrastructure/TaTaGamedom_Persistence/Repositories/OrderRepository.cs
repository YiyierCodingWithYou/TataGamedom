using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
    {
        this._httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> IsOrderExist(int orderId)
    {
        return await _dbContext.Orders.AnyAsync(o => o.Id == orderId);
    }

    public async Task<List<OrderWithDeatilsDto>> GetOrderWithDetailsByAccount()
    {
        string? account = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault()?.Value;

        var orderWithDeatilsList = await _dbContext.Orders
            .AsNoTracking()
            .Where(o => o.Member.Account == account)
            .OrderBy(o => o.OrderStatusId)
            .ThenByDescending(o => o.CreatedAt)
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

    public async Task<int> GetMaxId()
    {
        return await _dbContext.Orders.MaxAsync(o => o.Id);
    }
}


