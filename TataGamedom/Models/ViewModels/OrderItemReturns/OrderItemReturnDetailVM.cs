using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.OrderItemReturns
{
	public class OrderItemReturnDetailVM
	{
		public int Id { get; set; }

		[Display(Name = "退貨單代碼")]
		public string Index { get; set; }

		[Display(Name = "原訂單代碼")]
		public string OrderIndex { get; set; }

		[Display(Name = "退貨品項代碼")]
		public string OrderItemIndex { get; set; }

		[Display(Name = "商品售價")]
		public decimal OrderItemProductPrice { get; set; }

		[Display(Name = "庫存商品代碼")]
		public string InventoryItemIndex { get; set; }

		[Display(Name = "退貨理由")]
		public string Reason { get; set; }

		[Display(Name = "退貨日期")]
		public DateTime IssuedAt { get; set; }

		[Display(Name = "完成日期")]
		public DateTime? CompletedAt { get; set; }

		[Display(Name = "退款狀態")]
		public bool IsRefunded { get; set; }

		[Display(Name = "退貨狀態")]
		public bool IsReturned { get; set; }

		[Display(Name = "重新入庫")]
		public bool IsResellable { get; set; }
	}
}