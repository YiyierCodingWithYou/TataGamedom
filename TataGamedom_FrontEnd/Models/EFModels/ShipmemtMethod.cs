using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class ShipmemtMethod
    {
        public ShipmemtMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Cost { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
