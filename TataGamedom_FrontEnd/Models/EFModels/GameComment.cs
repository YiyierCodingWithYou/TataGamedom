using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels;

public partial class GameComment
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int MemberId { get; set; }

    public string Content { get; set; } = null!;

    public byte Score { get; set; }

    public DateTime CreatedTime { get; set; }

    public bool ActiveFlag { get; set; }

    public DateTime? DeleteDatetime { get; set; }

    public int? DeleteBackendMemberId { get; set; }

    public virtual BackendMember? DeleteBackendMember { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
