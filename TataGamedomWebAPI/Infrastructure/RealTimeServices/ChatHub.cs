using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using TataGamedomWebAPI.Application.Contracts.ChatService;
using TataGamedomWebAPI.Infrastructure.Data;

namespace TataGamedomWebAPI.Infrastructure.RealTimeServices;

public class ChatHub : Hub<IChatService>
{
    public async Task SendMessageToAll(string account, string messageContent, string memberName) 
    {
        await Clients.All.ReceiveMessage(account, messageContent, memberName);
    }

    public async Task SendPrivateMessage(string senderAccount, string messageContent, string memberName, string receiverAccount )
    {
        if (Context.User.Identity.IsAuthenticated && Context.User.Identity.Name == senderAccount)
        {
            await Clients.User(senderAccount).ReceivePrivateMessage(senderAccount, messageContent, memberName, receiverAccount);
            await Clients.User(receiverAccount).ReceivePrivateMessage(senderAccount, messageContent, memberName, receiverAccount);
        }
    }

}


