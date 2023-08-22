using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class BranchesOfSeven
{
    public int Id { get; set; }

    public string StoreNumber { get; set; } = null!;

    public string StoreName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;
}
