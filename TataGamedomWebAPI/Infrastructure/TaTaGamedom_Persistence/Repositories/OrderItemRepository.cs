using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemListByAccount;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<OrderItemWithDetailsDto>> GetListByAccountWithDetailsAsync(int orderId)
    {
        List<OrderItemWithDetailsDto> orderItemListWithDetails = await _dbContext.OrderItems
            .AsNoTracking() 
            .Where(oi => oi.OrderId == orderId)
            .Select(oi => new OrderItemWithDetailsDto
            {
                Id = oi.Id,
                Index = oi.Index,
                GameGameCoverImg = oi.Product!.Game!.GameCoverImg,
                GameChiName = oi.Product.Game.ChiName,
                DiscountedPrice = oi.ProductPrice,
                ProductIsVirtual = oi.Product.IsVirtual
            })
            .ToListAsync();

        return orderItemListWithDetails;
    }

    public async Task<string> GetOrderIndexById(int orderItemId)
    {
        string orderIndex = await _dbContext.OrderItems
            .AsNoTracking()
            .Where (oi => oi.Id == orderItemId)
            .Select(oi => oi.Order.Index!)
            .SingleAsync();

        return orderIndex;
    }

    public async Task<int> GetMaxId()
    {
        return await _dbContext.OrderItems.MaxAsync(oi => oi.Id);
    }

    public async Task<bool> IsOrderItemExist(int orderItemId)
    {
        return await _dbContext.OrderItems.AnyAsync(o => o.Id == orderItemId);
    }

}

