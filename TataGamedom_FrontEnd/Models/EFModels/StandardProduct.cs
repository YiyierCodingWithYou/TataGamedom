using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class StandardProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public bool? AutoOrder { get; set; }

    public int? Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;
}
