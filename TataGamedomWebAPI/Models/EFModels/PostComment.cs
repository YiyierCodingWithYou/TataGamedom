using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class PostComment
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int PostId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime Datetime { get; set; }

    public bool ActiveFlag { get; set; }

    public DateTime? DeleteDatetime { get; set; }

    public int? DeleteMemberId { get; set; }

    public int? DeleteBackendMemberId { get; set; }

    public int? ParentId { get; set; }

    public virtual BackendMember? DeleteBackendMember { get; set; }

    public virtual Member? DeleteMember { get; set; }

    public virtual ICollection<PostComment> InverseParent { get; set; } = new List<PostComment>();

    public virtual Member Member { get; set; } = null!;

    public virtual PostComment? Parent { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual ICollection<PostCommentReport> PostCommentReports { get; set; } = new List<PostCommentReport>();

    public virtual ICollection<PostCommentUpDownVote> PostCommentUpDownVotes { get; set; } = new List<PostCommentUpDownVote>();
}
