using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class BoardNotification
{
    public int Id { get; set; }

    public int RecipientMemberId { get; set; }

    public int? RelationMemberId { get; set; }

    public int? RelationPostId { get; set; }

    public string Content { get; set; } = null!;

    public string? Link { get; set; }

    public bool IsReaded { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime? ReadTime { get; set; }

    public virtual Member RecipientMember { get; set; } = null!;

    public virtual Member? RelationMember { get; set; }

    public virtual Post? RelationPost { get; set; }
}
