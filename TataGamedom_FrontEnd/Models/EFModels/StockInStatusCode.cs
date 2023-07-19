using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class StockInStatusCode
    {
        public StockInStatusCode()
        {
            StockInSheets = new HashSet<StockInSheet>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<StockInSheet> StockInSheets { get; set; }
    }
}
