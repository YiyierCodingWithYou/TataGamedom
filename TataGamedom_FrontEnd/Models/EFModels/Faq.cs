using System;
using System.Collections.Generic;

namespace TataGamedom_FrontEnd.Models.EFModels
{
    public partial class Faq
    {
        public int Id { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? IssueTypeId { get; set; }

        public virtual IssueTypesCode? IssueType { get; set; }
    }
}
