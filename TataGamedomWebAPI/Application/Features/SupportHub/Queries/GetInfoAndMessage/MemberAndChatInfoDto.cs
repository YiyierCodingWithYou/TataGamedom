using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage;

public class MemberAndChatInfoDto
{
    public string MemberAccount { get; set; } = string.Empty;

    public string MemberName { get; set; } = string.Empty;

    public string? MemberIconImg { get; set; } = string.Empty;

    public List<ChatMessageDto>? ChatMessages { get; set; }

}
