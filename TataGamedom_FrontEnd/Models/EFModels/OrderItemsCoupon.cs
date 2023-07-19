using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class OrderItemsCoupon
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int? CouponId { get; set; }

        public virtual Coupon? Coupon { get; set; }
        public virtual OrderItem OrderItem { get; set; } = null!;
    }
}
