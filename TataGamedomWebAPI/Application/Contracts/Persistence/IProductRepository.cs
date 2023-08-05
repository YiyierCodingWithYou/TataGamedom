using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task GetProductTopFiveSalesWithDetails();
    Task<bool> IsProductExist(int productId);
}
