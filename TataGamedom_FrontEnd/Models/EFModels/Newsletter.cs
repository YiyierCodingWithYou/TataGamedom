using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class Newsletter
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? BackendMemberId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BackendMember? BackendMember { get; set; }

    public virtual ICollection<NewsletterLog> NewsletterLogs { get; set; } = new List<NewsletterLog>();
}
