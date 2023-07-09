using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TataGamedom.Models.Dtos.OrderItemReturns;

namespace TataGamedom.Models.ViewModels.OrderItemReturns
{
	public class OrderItemReturnVM
	{
		public int Id { get; set; }

		[Display(Name = "退貨單代碼")]
		public string Index { get; set; }

		[Display(Name = "退貨品項代碼")]
		[Required(ErrorMessage = "{0} 必填")]
		public int OrderItemId { get; set; }

		[Display(Name = "退貨理由")]
		[Required(ErrorMessage = "{0} 必填")]
		public string Reason { get; set; }

		[Display(Name = "退貨日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} 必填")]
		public DateTime IssuedAt { get; set; }

		[Display(Name = "完成日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? CompletedAt { get; set; }

		[Display(Name = "退款狀態")]
		[Required(ErrorMessage = "{0} 必填")]
		public bool IsRefunded { get; set; }

		[Display(Name = "退貨狀態")]
		[Required(ErrorMessage = "{0} 必填")]
		public bool IsReturned { get; set; }

		[Display(Name = "重新入庫")]
		[Required(ErrorMessage = "{0} 必填")]
		public bool IsResellable { get; set; }
	}
	public static class OrderItemReturnExts 
	{
		public static OrderItemReturnDto ToDto(this OrderItemReturnVM vm) 
		{
			return new OrderItemReturnDto
			{
				Id = vm.Id,
				OrderItemId = vm.OrderItemId,
				Reason = vm.Reason,
				IssuedAt = vm.IssuedAt,
				CompletedAt = vm.CompletedAt,
				IsRefunded = vm.IsRefunded,
				IsReturned = vm.IsReturned,
				IsResellable = vm.IsResellable
			};
		}
	}
}