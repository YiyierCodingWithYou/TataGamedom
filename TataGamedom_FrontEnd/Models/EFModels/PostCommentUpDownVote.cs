using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class PostCommentUpDownVote
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int PostCommentId { get; set; }

    public DateTime Date { get; set; }

    public bool Type { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual PostComment PostComment { get; set; } = null!;
}
