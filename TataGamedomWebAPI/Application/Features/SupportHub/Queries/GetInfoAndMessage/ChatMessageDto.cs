namespace TataGamedomWebAPI.Application.Features.SupportHub.Queries.GetInfoAndMessage;

public class ChatMessageDto 
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

}
