using TataGamedom_FrontEnd.Models.EFModels;

namespace TataGamedom_FrontEnd.Models.Interfaces;

public interface IOrderRepository 
{
    Task<IEnumerable<Order>> GetOrderListAsync();
    
    Task<Order?> GetOrderByIdAsync(int id);

    Task<Order> AddOrderAsync(Order order);

    Task<int> UpdateOrderAsync(Order order);

    Task<int> DeleteOrderAsync(int id);


    //0723
    //void Add(Order order);

}
