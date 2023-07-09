using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.Games
{
	public class GameIndexVM
	{
		[Display(Name = "編號")]
		public int Id { get; set; }

		[Display(Name = "名稱")]
		public string ChiName { get; set; }
		//[Display(Name = "分類")]
		//public string Classification { get; set; }

		[Display(Name = "年齡限制")]
		public bool IsRestrict { get; set; }
		[Display(Name = "封面")]
		public string GameCoverImg { get; set; }

        [Display(Name = "創建者")]
		public string CreatedBackendMemberName { get; set; }

		[Display(Name = "創建時間")]
		public DateTime CreatedTime { get; set; }
		[Display(Name = "最後修改者")]
		public string ModifiedBackendMemberName { get; set; }
		[Display(Name = "最後修改時間")]
		public DateTime? ModifiedTime { get; set; }
	}
}