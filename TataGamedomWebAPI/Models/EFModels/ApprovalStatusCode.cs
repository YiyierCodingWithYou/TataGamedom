using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class ApprovalStatusCode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BoardsModeratorsApplication> BoardsModeratorsApplications { get; set; } = new List<BoardsModeratorsApplication>();
}
