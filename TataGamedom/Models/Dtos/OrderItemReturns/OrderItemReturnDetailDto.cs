using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TataGamedom.Models.ViewModels.OrderItemReturns;

namespace TataGamedom.Models.Dtos.OrderItemReturns
{
	public class OrderItemReturnDetailDto
	{
		public int Id { get; set; }

		public string Index { get; set; }

        public string OrderIndex { get; set; }

		public string OrderItemIndex { get; set; }

        public decimal OrderItemProductPrice{ get; set; }

        public string InventoryItemIndex{ get; set; }

        public string Reason { get; set; }

		public DateTime IssuedAt { get; set; }

		public DateTime? CompletedAt { get; set; }

		public bool IsRefunded { get; set; }

		public bool IsReturned { get; set; }

		public bool IsResellable { get; set; }
	}
	public static class OrderItemReturnDetailExts 
	{
		public static OrderItemReturnDetailVM ToVM(this OrderItemReturnDetailDto dto) 
		{
			return new OrderItemReturnDetailVM
			{
				Id = dto.Id,
				Index = dto.Index,
				OrderIndex = dto.OrderIndex,
				OrderItemIndex = dto.OrderItemIndex,
				OrderItemProductPrice = dto.OrderItemProductPrice,
				InventoryItemIndex = dto.InventoryItemIndex,
				Reason = dto.Reason,
				IssuedAt = dto.IssuedAt,
				CompletedAt = dto.CompletedAt,
				IsRefunded = dto.IsRefunded,
				IsReturned = dto.IsReturned,
				IsResellable = dto.IsResellable
			};
		}
	}
}