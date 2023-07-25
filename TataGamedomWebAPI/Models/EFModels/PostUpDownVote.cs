using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class PostUpDownVote
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int PostId { get; set; }

    public DateTime Date { get; set; }

    public bool Type { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
