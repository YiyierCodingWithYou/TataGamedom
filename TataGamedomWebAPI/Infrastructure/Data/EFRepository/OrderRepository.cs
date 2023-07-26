using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Immutable;
using TataGamedom.Infrastructure;
using TataGamedom_FrontEnd.Models.Interfaces;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Interfaces;

namespace TataGamedom_FrontEnd.Models.Infra.OrderInfra;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> AddOrderAsync(Order order)
    {
        var indexgenertor = new IndexGenerator(await _dbContext.Orders.MaxAsync(o => o.Id));
        order.Index = indexgenertor.GetOrderIndex(order);

        EntityEntry<Order> result = await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<int> DeleteOrderAsync(int id)
    {
        var order = await _dbContext.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
        if (order != null) 
        {
            _dbContext.Orders.Remove(order);
            return await _dbContext.SaveChangesAsync();
        }
        return 0;
    }


    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        var order = await _dbContext.Orders.AsNoTracking().Where(o => o.Id == id).FirstOrDefaultAsync();      
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrderListAsync()
    {
        var order = await _dbContext.Orders.AsNoTracking().ToListAsync();
        return order;
    }

    public async Task<int> UpdateOrderAsync(Order order)
    {
        _dbContext.Orders.Update(order);
        return await _dbContext.SaveChangesAsync();
    }
}
