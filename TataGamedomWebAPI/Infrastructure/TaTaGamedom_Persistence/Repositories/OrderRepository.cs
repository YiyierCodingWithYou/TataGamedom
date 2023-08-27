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
            .Where(o => o.OrderItems.Any())
            .OrderByDescending(o => o.CreatedAt)
            .Select(o => new OrderWithDeatilsDto
            {
                Id = o.Id,
                GameChiName = o.OrderItems.Select(oi => oi.InventoryItem.Product.Game!.ChiName).ToList(),
                ProductIsVirtual = o.OrderItems.Select(oi => oi.InventoryItem.Product.IsVirtual).ToList(),
                CreatedAt = o.CreatedAt,
                SentAt = o.SentAt,
                DeliveredAt = o.DeliveredAt,
                Total = o.OrderItems.Select(oi => oi.ProductPrice).Sum() + o.ShippingFee,
                OrderStatusCodeName = o.OrderStatus.Name,
                OrderIndex = o.Index,
                OrderCompletedAt = o.CompletedAt,
                OrderShipmentMethod = o.ShipmentMethod!.Name,
                OrderRecipientName = o.RecipientName,
                ContactEmails = o.ReceiverEmail,
                ToAddress = o.ToAddress,
            })
            .ToListAsync();

        return orderWithDeatilsList;
    }

    public async Task<int> GetMaxId()
    {
        return await _dbContext.Orders.MaxAsync(o => o.Id);
    }

    public async Task<string?> GetOrderIndexById(int orderId)
    {
        return await _dbContext.Orders
            .AsNoTracking()
            .Where(o => o.Id == orderId)
            .Select(o => o.Index)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateOrderStatusAfterReturn(int orderItemId)
    {
        var order = await _dbContext.OrderItems.Where(oi => oi.Id == orderItemId).Select(oi => oi.Order).FirstOrDefaultAsync();
        order!.OrderStatusId = (int)OrderStatus.ReturnProcessing;

        _dbContext.Entry(order).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Order?> GetByIndex(string index)
    {
        var order = await _dbContext.Orders
            .AsNoTracking()
            .Where(o => o.Index == index)
            .FirstOrDefaultAsync ();

        return order;
    }
}


