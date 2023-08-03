using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
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

    public async Task<OrderItemReturn?> GetDetailInckudeOrderItemAsync(int orderItemId)
    {
        OrderItemReturn? orderItemReturn = await _dbContext.OrderItemReturns.Include(o => o.OrderItem).FirstOrDefaultAsync(o => o.Id == orderItemId);

        return orderItemReturn;
    }
}

