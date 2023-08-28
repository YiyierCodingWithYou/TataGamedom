using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class OrderItemReturn
{
    public int Id { get; set; }

    public string? Index { get; set; }

    public int OrderItemId { get; set; }

    public string? Reason { get; set; }

    public DateTime IssuedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public bool IsRefunded { get; set; }

    public bool IsReturned { get; set; }

    public bool IsResellable { get; set; }

    public string? LinePayRefundTransactionId { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;
}
