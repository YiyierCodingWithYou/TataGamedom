using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    public MemberRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsMemberExist(int id)
    {
        return _dbContext.Members.AnyAsync(m => m.Id == id);
    }
}

