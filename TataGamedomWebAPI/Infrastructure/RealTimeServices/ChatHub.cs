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

    public async Task SendPrivateMessage(string senderAccount, string messageContent, string receiverAccount )
    {
        if (Context.User.Identity.IsAuthenticated && Context.User.Identity.Name == senderAccount)
        {
            Console.WriteLine($"IsAuthenticated: {Context.User.Identity.IsAuthenticated}, UserName: {Context.User.Identity.Name}");

            await Clients.User(receiverAccount).ReceivePrivateMessage(senderAccount, messageContent, receiverAccount);
            await Clients.User(receiverAccount).ReceivePrivateMessage(senderAccount, messageContent, receiverAccount);
        }
    }

}


