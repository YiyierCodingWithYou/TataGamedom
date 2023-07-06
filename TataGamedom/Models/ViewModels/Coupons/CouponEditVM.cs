using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static TataGamedom.Models.ViewModels.Coupons.CouponCreateVM;
using TataGamedom.Models.EFModels;

namespace TataGamedom.Models.ViewModels.Coupons
{
	public class CouponEditVM
	{
		public int Id { get; set; }
		[Display(Name = "活動名稱")]
		[Required]
		[StringLength(20)]
		public string Name { get; set; }
		[Display(Name = "折扣（填入數字）")]
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "數字必須大於0")]
		public int Discount { get; set; }
		public List<DiscountTypeCode> DiscountTypeCode { get; set; }
		[Display(Name = "折扣類型")]
		[Required]
		public int DiscountTypeId { get; set; }
		[Display(Name = "活動內容")]
		[Required]
		[StringLength(30)]
		public string Description { get; set; }
		[Display(Name = "最後修改時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? ModifiedTime { get; set; }
		[Display(Name = "最後修改者")]
		public string ModifiedBackendMemberName { get; set; }

		public int? ModifiedBackendMemberId { get; set; }
		[Display(Name = "門檻")]
		[Required]
		public int Threshold { get; set; }
		[Display(Name = "開始時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		[Required]
		public DateTime StartTime { get; set; }
		[Display(Name = "結束時間")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
		[Required]
		[EndTimeMustBeAfterStartTime(ErrorMessage = "結束時間不能早於開始時間")]
		public DateTime EndTime { get; set; }
		[Display(Name = "活動上線")]
		[Required]
		public bool ActiveFlag { get; set; }

		public class EndTimeMustBeAfterStartTimeAttribute : ValidationAttribute
		{
			protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			{
				var model = (CouponEditVM)validationContext.ObjectInstance;

				if (model.EndTime < model.StartTime)
				{
					return new ValidationResult(ErrorMessage);
				}

				return ValidationResult.Success;
			}
		}
	}
}