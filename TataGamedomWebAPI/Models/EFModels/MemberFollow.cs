using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class MemberFollow
{
    public int Id { get; set; }

    public int? FollowerMemberId { get; set; }

    public int? FollowedMemberId { get; set; }

    public virtual Member? FollowedMember { get; set; }

    public virtual Member? FollowerMember { get; set; }
}
