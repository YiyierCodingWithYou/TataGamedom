using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class NewsletterLog
    {
        public int Id { get; set; }
        public int? NewsletterId { get; set; }
        public DateTime EmailSentDatetime { get; set; }
        public int AddresseeMemberId { get; set; }
        public string AddresseeMemberName { get; set; } = null!;
        public string AddresseeMemberEmail { get; set; } = null!;

        public virtual Member AddresseeMember { get; set; } = null!;
        public virtual Newsletter? Newsletter { get; set; }
    }
}
