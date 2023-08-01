using System;
using System.Collections.Generic;
using TataGamedomWebAPI.Models.Common;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class OrderItem
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal ProductPrice { get; set; }

    public int InventoryItemId { get; set; }

    public virtual InventoryItem InventoryItem { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual OrderItemReturn? OrderItemReturn { get; set; }

    public virtual ICollection<OrderItemsCoupon> OrderItemsCoupons { get; set; } = new List<OrderItemsCoupon>();

    public virtual Product Product { get; set; } = null!;
}

