using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TataGamedom.Models.ViewModels.OrderItemReturns;

namespace TataGamedom.Models.Dtos.OrderItemReturns
{
	public class OrderItemReturnIndexDto
	{
		public int Id { get; set; }

		public string Index { get; set; }

		public string OrderIndex { get; set; }

		public string OrderItemIndex { get; set; }

		public DateTime IssuedAt { get; set; }

		public DateTime? CompletedAt { get; set; }

		public bool IsRefunded { get; set; }

		public bool IsReturned { get; set; }

		public bool IsResellable { get; set; }
	}
	public static class OrderItemReturnIndexExts 
	{
		public static OrderItemReturnIndexVM ToVM(this OrderItemReturnIndexDto dto) 
		{
			return new OrderItemReturnIndexVM
			{
				Id = dto.Id,
				Index = dto.Index,
				OrderIndex = dto.OrderIndex,
				OrderItemIndex = dto.OrderItemIndex,
				IssuedAt = dto.IssuedAt,
				CompletedAt = dto.CompletedAt,
				IsRefunded = dto.IsRefunded,
				IsReturned = dto.IsReturned,
				IsResellable = dto.IsResellable
			};
		} 
	}
}