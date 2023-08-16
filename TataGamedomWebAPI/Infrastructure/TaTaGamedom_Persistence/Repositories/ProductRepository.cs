using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base (dbContext)
    {
    }

    public async Task<string> GetIndexById(int productId)
    {
        return await _dbContext.Products.Where(p => p.Id == productId).Select(p => p.Index).FirstAsync();
    }

    public async Task<bool> IsProductExist(int productId)
    {
        return await _dbContext.Products.AnyAsync(p => p.Id == productId);
    }

    async Task<List<Product>> IProductRepository.GetProductTopFiveSalesWithDetails()
    {
        List<int> productTopFiveSaleId = await _dbContext.OrderItems
            .GroupBy(o => o.InventoryItem.ProductId)
            .OrderByDescending(o => o.Count())
            .Select(g => g.Key)
            .Take(5)
            .ToListAsync();

        List<Product> productsWithDetails = await _dbContext.Products
            .Where(p => productTopFiveSaleId.Contains(p.Id))
            .Include(p => p.Game)
            .Include(p => p.GamePlatform)
            .ToListAsync();

        return productsWithDetails;
    }
}

