using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class StockInSheet
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int StockInStatusId { get; set; }

    public int SupplierId { get; set; }

    public int Quantity { get; set; }

    public DateTime OrderRequestDate { get; set; }

    public DateTime? ArrivedAt { get; set; }

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public virtual StockInStatusCode StockInStatus { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
