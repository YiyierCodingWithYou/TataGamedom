using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.Reports
{
	public class ReportListVm
	{
		public string Type { get; set; }
		public int ReportId { get; set; }
		public string Index { get; set; }
		public string Reason { get; set; }
		public DateTime Datetime { get; set; }
		public string Account { get; set; }
		public int BoardId { get; set; }
		public string BoardName { get; set; }
		public int ReportedId { get; set; }
		public int PostId { get; set; }
		public string ReportedContent { get; set; }
		public int ReportedContentStatus { get; set; }
		public string ReportedAccount { get; set; }
		public bool IsCommit { get; set; }
		public string IsCommitText { get; set; }
		public string ReviewerBackendMemberAccount { get; set; }
		public string ReviewComment { get; set; }
		public DateTime? ReviewDatetime { get; set; }
	}
}