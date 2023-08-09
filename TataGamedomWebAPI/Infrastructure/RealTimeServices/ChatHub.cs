using Microsoft.AspNetCore.SignalR;

namespace TataGamedomWebAPI.Infrastructure.RealTimeServices;

public class ChatHub : Hub
{
    public async Task SendMessage(string account, string messageContent) 
    {
        ChatService chatService = Context.GetHttpContext()!.RequestServices.GetService<ChatService>()!;
        await chatService.SendMessage(account, messageContent);
    }
}

