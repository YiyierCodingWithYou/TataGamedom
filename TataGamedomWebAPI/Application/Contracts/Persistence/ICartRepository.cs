using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface ICartRepository : IGenericRepository<Cart>
{
	Task<Cart?> GetByMemberIdAsync(int memberId);
	Task<List<Cart>?> GetCartListByMemberIdAsync(int memberId);
}
