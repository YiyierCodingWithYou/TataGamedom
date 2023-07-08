using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.BoardsModerators
{
	public class BoardsModeratorListVm
	{
		public int Id { get; set; }
		public string BoardName { get; set; }
		public string MemberAccount { get; set;}
		public DateTime LastOnlineTime { get; set;}
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string Status { get; set; }
	}
}