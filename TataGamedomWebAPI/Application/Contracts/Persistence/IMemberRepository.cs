using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IMemberRepository : IGenericRepository<InventoryItem>
{
    Task<bool> IsMemberExist(int id);
}
