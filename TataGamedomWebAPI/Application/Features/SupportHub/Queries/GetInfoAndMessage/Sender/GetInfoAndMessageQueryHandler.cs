using MediatR;
using TataGamedomWebAPI.Application.Contracts.Logging;
using TataGamedomWebAPI.Application.Contracts.Persistence;
using TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage.Receiver;

namespace TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage.Sender;

public class GetInfoAndMessageQueryHandler : IRequestHandler<GetInfoAndMessageQuery, MemberAndChatInfoDto?>
{
    private readonly IMemberRepository _memberRepository;

    public GetInfoAndMessageQueryHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public async Task<MemberAndChatInfoDto?> Handle(GetInfoAndMessageQuery request, CancellationToken cancellationToken)
    {
        var memberAndChatInfo = await _memberRepository.GetLoginMemberChatInfo();

        return memberAndChatInfo;
    }
}

