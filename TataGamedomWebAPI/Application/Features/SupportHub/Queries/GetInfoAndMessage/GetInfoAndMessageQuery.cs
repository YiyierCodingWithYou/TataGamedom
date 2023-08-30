using MediatR;

namespace TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage;

public record GetInfoAndMessageQuery: IRequest<MemberAndChatInfoDto?>
{
}
