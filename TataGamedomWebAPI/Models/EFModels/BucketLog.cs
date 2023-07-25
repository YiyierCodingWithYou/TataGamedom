using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class BucketLog
{
    public int Id { get; set; }

    public int BucketMemberId { get; set; }

    public int? ModeratorMemberId { get; set; }

    public int? BackendMmemberId { get; set; }

    public int BoardId { get; set; }

    public string BucketReason { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsNoctified { get; set; }

    public virtual BackendMember? BackendMmember { get; set; }

    public virtual Board Board { get; set; } = null!;

    public virtual Member BucketMember { get; set; } = null!;

    public virtual Member? ModeratorMember { get; set; }
}
