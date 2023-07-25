using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class StockInStatusCode
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StockInSheet> StockInSheets { get; set; } = new List<StockInSheet>();
}
