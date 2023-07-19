using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class NewsComment
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Time { get; set; }
        public int MemberId { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime? DeleteDatetime { get; set; }
        public int? DeleteMemberId { get; set; }
        public int? DeleteBackendMemberId { get; set; }

        public virtual BackendMember? DeleteBackendMember { get; set; }
        public virtual Member? DeleteMember { get; set; }
        public virtual Member Member { get; set; } = null!;
        public virtual News News { get; set; } = null!;
    }
}
