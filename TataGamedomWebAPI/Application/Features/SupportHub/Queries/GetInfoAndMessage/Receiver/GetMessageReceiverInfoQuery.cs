using MediatR;

namespace TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage.Receiver;

public record GetMessageReceiverInfoQuery(string ReceiverAccount) : IRequest<MemberAndChatInfoDto?>
{
}