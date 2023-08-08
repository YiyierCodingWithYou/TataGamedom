using System;
using System.Collections.Generic;

namespace TataGamedomWebAPI.Models.EFModels;

public partial class Post
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int? BoardId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime Datetime { get; set; }

    public DateTime LastEditDatetime { get; set; }

    public bool ActiveFlag { get; set; }

    public DateTime? DeleteDatetime { get; set; }

    public int? DeleteMemberId { get; set; }

    public int? DeleteBackendMemberId { get; set; }

    public virtual Board? Board { get; set; }

    public virtual BackendMember? DeleteBackendMember { get; set; }

    public virtual Member? DeleteMember { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostEditLog> PostEditLogs { get; set; } = new List<PostEditLog>();

    public virtual ICollection<PostReport> PostReports { get; set; } = new List<PostReport>();

    public virtual ICollection<PostUpDownVote> PostUpDownVotes { get; set; } = new List<PostUpDownVote>();
}
