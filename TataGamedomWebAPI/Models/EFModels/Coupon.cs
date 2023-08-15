using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class Coupon
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Discount { get; set; }

    public int DiscountTypeId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public int CreatedBackendMemberId { get; set; }

    public int Threshold { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool ActiveFlag { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? ModifiedBackendMemberId { get; set; }

    public virtual ICollection<CouponsProduct> CouponsProducts { get; set; } = new List<CouponsProduct>();

    public virtual BackendMember CreatedBackendMember { get; set; } = null!;

    public virtual DiscountTypeCode DiscountType { get; set; } = null!;

    public virtual BackendMember? ModifiedBackendMember { get; set; }

    public virtual ICollection<OrderItemsCoupon> OrderItemsCoupons { get; set; } = new List<OrderItemsCoupon>();
}
