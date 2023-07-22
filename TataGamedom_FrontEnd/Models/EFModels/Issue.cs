using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class Issue
{
    public int Id { get; set; }

    public int? MemberId { get; set; }

    public int? IssueTypeId { get; set; }

    public string Content { get; set; } = null!;

    public string? File { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Status { get; set; }

    public virtual IssueTypesCode? IssueType { get; set; }

    public virtual Member? Member { get; set; }

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();

    public virtual IssueStatusCode? StatusNavigation { get; set; }
}
