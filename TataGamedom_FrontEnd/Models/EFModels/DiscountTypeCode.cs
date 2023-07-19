using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class DiscountTypeCode
    {
        public DiscountTypeCode()
        {
            Coupons = new HashSet<Coupon>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
