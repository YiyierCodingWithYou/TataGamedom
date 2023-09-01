using MediatR;
using TataGamedomWebAPI.Application.Contracts.Persistence;

namespace TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage.Receiver;


public class GetMessageReceiverInfoQueryHandler : IRequestHandler<GetMessageReceiverInfoQuery, MemberAndChatInfoDto?>
{
    private readonly IMemberRepository _memberRepository;

    public GetMessageReceiverInfoQueryHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<MemberAndChatInfoDto?> Handle(GetMessageReceiverInfoQuery request, CancellationToken cancellationToken)
    {
        var receiverInfo = await _memberRepository.GetMessageReceiverInfo(request.ReceiverAccount);

        return receiverInfo;
    }
}

