using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class IssueTypesCode
{
    public int Id { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Faq> Faqs { get; set; } = new List<Faq>();

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
