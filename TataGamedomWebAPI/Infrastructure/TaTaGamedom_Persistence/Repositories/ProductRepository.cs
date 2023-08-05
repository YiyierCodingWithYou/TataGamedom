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

    public async Task GetProductTopFiveSalesWithDetails()
    {
        List<IGrouping<int, int>> productTopFiveSales = await _dbContext.OrderItems
            .GroupBy(o => o.ProductId, o => o.ProductId)
            .OrderByDescending(o => o.Count())
            .Take(5)
            .ToListAsync();



        var topFiveSalesWithDetails = await _dbContext.Products
            .Include(p => p.Game)
            .Include(p => p.GamePlatform)
            //.Where(p => p.Id == productTopFiveSales.)
            //Todo
    }

    public async Task<bool> IsProductExist(int productId)
    {
        return await _dbContext.Products.AnyAsync(p => p.Id == productId);
    }
}

