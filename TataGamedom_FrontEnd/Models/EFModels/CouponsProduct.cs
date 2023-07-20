using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class CouponsProduct
{
    public int Id { get; set; }

    public int CouponId { get; set; }

    public int ProductId { get; set; }

    public virtual Coupon Coupon { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
