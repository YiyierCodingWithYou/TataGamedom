using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.TaTaGamedom_Persistence.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MemberRepository(AppDbContext dbContext,IHttpContextAccessor httpContextAccessor) : base(dbContext)
    {
        this._httpContextAccessor = httpContextAccessor;
    }


    public async Task<bool> IsMemberExist(int id)
    {
        return await _dbContext.Members.AnyAsync(m => m.Id == id);
    }

    public async Task<MemberAndChatInfoDto?> GetLoginMemberChatInfo()
    {
        string? account = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault()?.Value;

        List<ChatMessageDto> chatMessages = await GetChatMessagesByAccount(account);

        MemberAndChatInfoDto? memberAndChatInfo = await _dbContext.Members
            .AsNoTracking()
            .Where(m => m.Account == account)
            .Select(m => new MemberAndChatInfoDto
            {
                MemberAccount = m.Account,
                MemberName = m.Name,
                MemberIconImg = m.IconImg,
                ChatMessages = chatMessages
            })
            .FirstOrDefaultAsync();

        return memberAndChatInfo;
    }

    private async Task<List<ChatMessageDto>> GetChatMessagesByAccount(string? account)
    {
        return await _dbContext.ChatMessages
            .AsNoTracking()
            .Where(c => c.Member.Account == account)
            .Select(c => new ChatMessageDto
            {
                Id = c.Id,
                MemberId = c.Member.Id,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();
    }
}

