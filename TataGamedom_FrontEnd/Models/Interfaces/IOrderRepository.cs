using TataGamedom_FrontEnd.Models.EFModels;

namespace TataGamedom_FrontEnd.Models.Interfaces;

public interface IOrderRepository 
{
    Task<IEnumerable<Order>> GetAll();
    
    Task<Order> Get(int id);

    Task<Order> Create(Order order);

    Task<int> Update(Order order);

    Task<int> Delete(int id);


    //0723
    void Add(Order order);

}
