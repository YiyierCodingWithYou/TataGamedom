using Microsoft.AspNetCore.SignalR;
using TataGamedomWebAPI.Application.Contracts.ChatService;

namespace TataGamedomWebAPI.Infrastructure.RealTimeServices;

public class ChatHub : Hub<IChatService>
{
    public async Task SendMessageToAll(string account, string messageContent, string memberName) 
    {
        await Clients.All.ReceiveMessage(account, messageContent, memberName);
    }

    public async Task SendPrivateMessage(string senderAccount, string messageContent, string receiverAccount )
    {
        await Clients.User(receiverAccount).ReceivePrivateMessage(senderAccount, messageContent, receiverAccount);
    }
}


