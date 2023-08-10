using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using TataGamedomWebAPI.Application.Contracts.ChatService;

namespace TataGamedomWebAPI.Infrastructure.RealTimeServices;

public class ChatHub : Hub<IChatService>
{
    public async Task SendMessageToAll(string account, string messageContent) 
    {
        await Clients.All.ReceiveMessage(account, messageContent);
    }
}

