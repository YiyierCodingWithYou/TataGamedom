using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.ViewModels.Orders;

namespace TataGamedom.Models.ViewModels.Members
{
	public class BackendMembersEditVM: IValidatableObject
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

				var model = validationContext.ObjectInstance as BackendMembersEditVM;

				if (model.BackendMembersRoleId == 0 || model.BackendMembersRoleId == null)
				{
				yield return new ValidationResult("請選擇權限", new[] { nameof(BackendMembersRoleId) });

			}

		}
	}
}