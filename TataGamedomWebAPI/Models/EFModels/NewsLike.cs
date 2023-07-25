using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class NewsLike
{
    public int Id { get; set; }

    public int NewsId { get; set; }

    public int MemberId { get; set; }

    public DateTime Time { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual News News { get; set; } = null!;
}
