using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
	public CartRepository(AppDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<Cart?> GetByMemberIdAsync(int memberId)
	{
		return await _dbContext.Carts.Where(c => c.MemberId == memberId).FirstOrDefaultAsync();
	}

	public async Task<List<Cart>?> GetCartListByMemberIdAsync(int memberId)
	{
		return await _dbContext.Carts.Where(c => c.MemberId == memberId).ToListAsync();
	}
}
