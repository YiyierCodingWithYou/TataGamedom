using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.ViewModels.Orders;

namespace TataGamedom.Models.ViewModels.Members
{
	public class BackendMembersListVM: IValidatableObject
	{
		public int Id { get; set; }
		[Display(Name = "管理員名稱")]
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Display(Name = "管理員帳號")]
		[Required]
		[StringLength(30)]
		public string Account { get; set; }
		[Required]
		[Display(Name = "密碼")]
		[DataType(DataType.Password)]
		[StringLength(70)]
		public string Password { get; set; }

		[Display(Name = "確認密碼")]
		[Required]
		[StringLength(70)]
		[Compare("Password", ErrorMessage = "必須與'密碼'欄位值相同")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
		[Display(Name = "生日")]
		public DateTime Birthday { get; set; }
		[Required]
		[Display(Name = "信箱")]
		[StringLength(150)]
		[EmailAddress(ErrorMessage = "Email格式有誤")]
		public string Email { get; set; }
		[Display(Name = "手機")]
		[Required]
		[StringLength(10)]
		public string Phone { get; set; }
		[Display(Name = "權限名稱")]
		[Required]
		public int? BackendMembersRoleId { get; set; }

		[Display(Name="權限名稱")]
	
		public string BackendMembersRoleName { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
		public DateTime? RegistrationDate { get; set; }
		[Display(Name = "帳號狀態")]
		public bool ActiveFlag { get; set; }

		public string ActiveFlagText
		{
			get
			{
				return ActiveFlag == true ? "使用中" : "停權";
			}
		}

		public virtual BackendMembersRolesCode BackendMembersRolesCode { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			
				//var db = new AppDbContext();

				var model = validationContext.ObjectInstance as BackendMembersListVM;

				if (model.BackendMembersRoleId == 0 || model.BackendMembersRoleId == null)
				{
				yield return new ValidationResult("請選擇權限", new[] { nameof(BackendMembersRoleId) });

			}

			//if (model.MemberId != 0 && db.Members.Any(m => m.Id == model.MemberId) == false)
			//{
			//	yield return new ValidationResult("該會員編號不存在", new List<string> { "MemberId" });
			//}

			//if (model.SentAt.HasValue && model.DeliveredAt.HasValue && model.DeliveredAt < model.SentAt)
			//{
			//	yield return new ValidationResult("抵達日期不能晚於寄送日期", new List<string> { "SentAt", "CreatedAt" });
			//}

		}
	}
}