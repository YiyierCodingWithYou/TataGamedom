using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Application.Contracts.ChatService;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure.RealTimeServices;

public class ChatService : IChatServices
{
    private readonly IHubContext<ChatHub> _hubContext;
    private readonly AppDbContext _dbContext;

    public ChatService(IHubContext<ChatHub> hubContext, AppDbContext dbContext)
    {
        this._hubContext = hubContext;
        this._dbContext = dbContext;
    }

    public async Task SendMessage(string account, string messageContent)
    {
        Member? member = await _dbContext.Members.FirstOrDefaultAsync(m => m.Account == account);
        BackendMember? backendMember = await _dbContext.BackendMembers.FirstOrDefaultAsync(b => b.Account == account);

        var message = new ChatMessage
        { 
            Content = messageContent,
            Timestamp = DateTime.Now,
            Member = member,
            BackendMember = backendMember,
        };

        await _dbContext.AddAsync(message);
        await _dbContext.SaveChangesAsync();
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);     
    }
}

