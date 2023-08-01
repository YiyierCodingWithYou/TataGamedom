using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Contracts.Persistence;

public interface IMemberRepository : IGenericRepository<Member>
{
    Task<bool> IsMemberExist(int id);
}
