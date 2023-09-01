using MediatR;

namespace TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage.Sender;

public record GetInfoAndMessageQuery : IRequest<MemberAndChatInfoDto?>
{
}
