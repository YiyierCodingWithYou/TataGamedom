using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using TataGamedomWebAPI.Application.Contracts.ChatService;
using TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage;
using TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage.Receiver;

namespace TataGamedomWebAPI.Infrastructure.RealTimeServices;

public class ChatHub : Hub<IChatService>
{
    private readonly IMediator _mediator;

    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task SendMessageToAll(string account, string messageContent, string memberName) 
    {
        await Clients.All.ReceiveMessage(account, messageContent, memberName);
    }

    public async Task SendPrivateMessage(string senderAccount, string messageContent, string memberName, string receiverAccount )
    {
        MemberAndChatInfoDto? receiverChatInfo = await _mediator.Send(new GetMessageReceiverInfoQuery(receiverAccount));
        MemberAndChatInfoDto? senderChatInfo = await _mediator.Send(new GetMessageReceiverInfoQuery(senderAccount));


        if (Context?.User?.Identity?.IsAuthenticated == true && Context.User.Identity.Name == senderAccount)
        {
            string sendAt = DateTime.Now.ToString("HH:mm");

            await Clients.User(senderAccount).ReceivePrivateMessage(senderAccount, messageContent, memberName, receiverAccount, sendAt, receiverChatInfo?.MemberIconImg);  //讓發訊息的收到收訊息的人的照片

            await Clients.User(receiverAccount).ReceivePrivateMessage(senderAccount, messageContent, memberName, receiverAccount, sendAt, senderChatInfo?.MemberIconImg);  //相反
        }
    }

}


