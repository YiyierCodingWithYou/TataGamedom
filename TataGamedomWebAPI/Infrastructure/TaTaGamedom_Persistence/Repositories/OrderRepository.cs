using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
public class OrderItemReturnRepository : GenericRepository<OrderItemReturn>, IOrderItemReturnRepository
{
    public OrderItemReturnRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
public class InventoryItemRepository : GenericRepository<InventoryItem>, IInventoryItemRepository
{
    public InventoryItemRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    public MemberRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsMemberExist(int id)
    {
        return _dbContext.Members.AnyAsync(m => m.Id == id);
    }
}

