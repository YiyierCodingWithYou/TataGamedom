//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using TataGamedom_FrontEnd.Models.EFModels;
//using TataGamedom_FrontEnd.Models.Interfaces;

//namespace TataGamedom_FrontEnd.Models.Infra.Order;

//public class OrderRepository : IOrderRepository
//{
//    private readonly AppDbContext _dbContext;

//    public OrderRepository(AppDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    public async Task<Order> Create(Order order)
//    {
//        EntityEntry<Order> result = _dbContext.Orders.Add(order);
//        await _dbContext.SaveChangesAsync();
//        return result.Entity;
//    }

//    public async Task<int> Delete(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<Order> Get(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<IEnumerable<Order>> GetAll()
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<int> Update(Order order)
//    {
//        throw new NotImplementedException();
//    }
//}
