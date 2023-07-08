using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.BucketLogs
{
	public class BucketLogListVm
	{
		public int Id { get; set; }
		public string BucketMemberAccount { get; set; }
		public string ActionType { get; set; }
		public string ActionAccount { get; set; }
		public string BoardName { get; set; }
		public string BucketReason { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }
		public string IsNoticedText { get; set; }
		public string BucketStatus { get; set; }
	}
}