using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.BoardsModerators
{
	public class BoardsModeratorsApplicationListVm
	{
		public int Id { get; set; }

		public string MemberAccount { get; set; }

		public string BoardName { get; set; }

		public DateTime ApplyDate { get; set; }

		public bool AddOrRemove { get; set; }

		public string AddOrRemoveText { get; set; }

		[Required]
		[StringLength(500)]
		public string ApplyReason { get; set; }
		public string ApprovalStatus { get; set; }
		public bool? ApprovalResult { get; set; }
		
		public string ApprovalResultText { get; set; }
		
		public string BackendMemberAccount { get; set; }
		
		public DateTime? ApprovalStatusDate { get; set; }
	}
}