using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.ViewModels.Coupons;
using TataGamedom.Models.ViewModels.Members;

namespace TataGamedom.Models.ViewModels.Games
{
	public class GameCreateVM:IValidatableObject
	{
		public int Id { get; set; }

		[Display(Name = "中文名稱")]
		[Required]
		[StringLength(50)]
		public string ChiName { get; set; }

		[Display(Name = "英文名稱")]
		[Required]
		[StringLength(100)]

		public string EngName { get; set; }

		public List<GameClassificationsCode> GameClassification { get; set; }
		[Display(Name = "遊戲類別（複選最多兩項）")]
		[Required]
		public List<int> SelectedGameClassification { get; set; }

		[Display(Name = "遊戲介紹")]
		[Required]
		[StringLength(1500)]
		public string Description { get; set; }
		[Display(Name = "年齡限制")]
		[Required]
		public bool IsRestrict { get; set; }

		[Display(Name = "封面圖片")]
		[Required]
		public string GameCoverImg { get; set; }

		[Display(Name = "創建時間")]

		public DateTime CreatedTime { get; set; }
		[Display(Name = "創建者")]

		public int CreatedBackendMemberId { get; set; }


		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var model = validationContext.ObjectInstance as GameCreateVM;

			if (model.SelectedGameClassification != null && model.SelectedGameClassification.Count > 2)
			{
				yield return new ValidationResult("最多只能選擇兩項分類！", new List<string> { "SelectedGameClassification" });
			}
		}
	}
}