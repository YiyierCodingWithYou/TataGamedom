using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class MembersBoard
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int BoardId { get; set; }

    public bool IsFavorite { get; set; }

    public virtual Board Board { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
