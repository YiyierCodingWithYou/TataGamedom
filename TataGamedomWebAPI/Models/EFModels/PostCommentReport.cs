using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class PostCommentReport
{
    public int Id { get; set; }

    public int PostCommentId { get; set; }

    public int MemberId { get; set; }

    public DateTime Datetime { get; set; }

    public string Reason { get; set; } = null!;

    public int? ReviewerBackenMemberId { get; set; }

    public DateTime? ReviewDatetime { get; set; }

    public bool IsCommit { get; set; }

    public string? ReviewComment { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual PostComment PostComment { get; set; } = null!;

    public virtual BackendMember? ReviewerBackenMember { get; set; }
}
