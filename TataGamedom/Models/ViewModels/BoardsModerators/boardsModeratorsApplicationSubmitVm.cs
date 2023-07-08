using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.BoardsModerators
{
	public class BoardsModeratorsApplicationSubmitVm
	{
		public bool ApprovalResult { get; set; }
		public string BoardName { get; set; }
		public string  MemberAccount { get; set; }
	}
}