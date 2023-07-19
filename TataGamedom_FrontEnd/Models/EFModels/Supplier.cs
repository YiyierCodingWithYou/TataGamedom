using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class Supplier
    {
        public Supplier()
        {
            StockInSheets = new HashSet<StockInSheet>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<StockInSheet> StockInSheets { get; set; }
    }
}
