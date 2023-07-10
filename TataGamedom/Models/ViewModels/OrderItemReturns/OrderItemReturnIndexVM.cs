using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.OrderItemReturns
{
	public class OrderItemReturnIndexVM
	{
		public int Id { get; set; }

		[Display(Name = "退貨單編號")]
		public string Index { get; set; }

		[Display(Name = "訂單代碼")]
		public string OrderIndex{ get; set; }
        
		[Display(Name = "退貨品項代碼")]
		public string OrderItemIndex { get; set; }

		[Display(Name = "退貨日期")]
		[DataType(DataType.Date)]
		public DateTime IssuedAt { get; set; }

		[Display(Name = "完成日期")]
		[DataType(DataType.Date)]
		public DateTime? CompletedAt { get; set; }

		[Display(Name = "退款狀態")]
		[Required]
		public bool IsRefunded { get; set; }
		public string IsRefundedText => IsRefunded ? "已退款" : "未退款";

        [Display(Name = "退貨狀態")]
		[Required]
		public bool IsReturned { get; set; }
		public string IsReturnedText => IsReturned ? "已退貨" : "未退貨";

		[Display(Name = "重新入庫")]
		[Required]
		public bool IsResellable { get; set; }
		public string IsResellableText => IsResellable ? "重新入庫" : "不重新入庫";

	}
}