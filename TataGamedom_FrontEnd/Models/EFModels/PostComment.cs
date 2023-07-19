using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class PostComment
    {
        public PostComment()
        {
            InverseParent = new HashSet<PostComment>();
            PostCommentReports = new HashSet<PostCommentReport>();
            PostCommentUpDownVotes = new HashSet<PostCommentUpDownVote>();
        }

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
        public virtual Member Member { get; set; } = null!;
        public virtual PostComment? Parent { get; set; }
        public virtual Post Post { get; set; } = null!;
        public virtual ICollection<PostComment> InverseParent { get; set; }
        public virtual ICollection<PostCommentReport> PostCommentReports { get; set; }
        public virtual ICollection<PostCommentUpDownVote> PostCommentUpDownVotes { get; set; }
    }
}
