using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class PostEditLog
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ContentBeforeEdit { get; set; } = null!;
        public DateTime EditDatetime { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
