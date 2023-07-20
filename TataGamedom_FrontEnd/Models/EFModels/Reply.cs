using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class Reply
{
    public int Id { get; set; }

    public int? IssueId { get; set; }

    public int? BackendMemberId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Content { get; set; } = null!;

    public virtual BackendMember? BackendMember { get; set; }

    public virtual Issue? Issue { get; set; }
}
