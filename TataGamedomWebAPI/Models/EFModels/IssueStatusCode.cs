using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class IssueStatusCode
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Issue> Issues { get; set; } = new List<Issue>();
}
