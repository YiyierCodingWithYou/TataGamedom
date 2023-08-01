using System;
using System.Collections.Generic;
using TataGamedomWebAPI.Models.Common;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class OrderItemReturn : BaseEntity
{
    public string Index { get; set; } = null!;

    public int OrderItemId { get; set; }

    public string Reason { get; set; } = null!;

    public DateTime IssuedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public bool IsRefunded { get; set; }

    public bool IsReturned { get; set; }

    public bool IsResellable { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;
}
