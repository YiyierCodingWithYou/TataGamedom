using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class NewsView
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int MemberId { get; set; }
        public DateTime ViewTime { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual News News { get; set; } = null!;
    }
}
