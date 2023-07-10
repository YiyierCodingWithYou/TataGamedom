using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.BucketLogs
{
	public class BucketLogsAddVm
	{

		public int Id { get; set; }

		[Required] 
		public string BucketMemberAccount { get; set; }
		[Required] 
		public string BoardName { get; set; }
		[Required] 
		public string BucketReason { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Days must be greater than zero.")]
		public int Days { get; set; }
	}
}