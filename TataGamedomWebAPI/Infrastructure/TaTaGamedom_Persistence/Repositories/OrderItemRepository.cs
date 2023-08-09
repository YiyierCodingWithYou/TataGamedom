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

    public async Task<bool> IsOrderItemExist(int orderItemId)
    {
        return await _dbContext.OrderItems.AnyAsync(o => o.Id == orderItemId);
    }

    public async Task<List<OrderItemWithDetailsDto>> GetListByAccountWithDetailsAsync(int orderId)
    {
        //Todo DiscountedPrice跟112確定後改用算的，或反正規化直接取值
        List<OrderItemWithDetailsDto> orderItemListWithDetails = await _dbContext.OrderItems
            .AsNoTracking() 
            .Where(oi => oi.OrderId == orderId)
            .Select(oi => new OrderItemWithDetailsDto
            {
                Id = oi.Id,
                GameGameCoverImg = oi.Product.Game!.GameCoverImg,
                GameChiName = oi.Product.Game.ChiName,
                DiscountedPrice = 0,
                ProductIsVirtual = oi.Product.IsVirtual
            })
            .ToListAsync();

        return orderItemListWithDetails;
    }
}

