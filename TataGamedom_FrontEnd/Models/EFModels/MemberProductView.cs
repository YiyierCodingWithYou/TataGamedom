using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class MemberProductView
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public DateTime ViewTime { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
