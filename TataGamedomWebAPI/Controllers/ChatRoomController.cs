using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage;
using TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage.Sender;

namespace TataGamedomWebAPI.Controllers;

[EnableCors("AllowAny")]
[Route("api/[controller]")]
[ApiController]
public class ChatRoomController : ControllerBase
{

    private readonly IMediator _mediator;

    public ChatRoomController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("MemberAndChatInfo")]
    [EnableCors("AllowCookie")]
    public async Task<MemberAndChatInfoDto?> Get()
    {
        var memberAndChatInfo = await _mediator.Send(new GetInfoAndMessageQuery());
        return memberAndChatInfo;
    }


}
