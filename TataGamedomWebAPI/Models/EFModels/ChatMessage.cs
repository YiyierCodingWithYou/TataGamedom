using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class ChatMessage
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Member Member { get; set; } = null!;
}
