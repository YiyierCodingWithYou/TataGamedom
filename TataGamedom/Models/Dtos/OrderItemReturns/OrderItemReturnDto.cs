using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.ViewModels.OrderItemReturns;

namespace TataGamedom.Models.Dtos.OrderItemReturns
{
	public class OrderItemReturnDto
	{
		public int Id { get; set; }

        public string Index { get; set; }
        
		public int OrderItemId { get; set; }

		public string Reason { get; set; }

		public DateTime IssuedAt { get; set; }

		public DateTime? CompletedAt { get; set; }

		public bool IsRefunded { get; set; }

		public bool IsReturned { get; set; }

		public bool IsResellable { get; set; }

	}
	public static class OrderItemReturnExts 
	{
		public static OrderItemReturnDto ToDto(this OrderItemReturn entity) 
		{
			return new OrderItemReturnDto
			{
				Id = entity.Id,
				Index = entity.Index,
				OrderItemId = entity.OrderItemId,
				Reason = entity.Reason,
				IssuedAt = entity.IssuedAt,
				CompletedAt = entity.CompletedAt,
				IsRefunded = entity.IsRefunded,
				IsReturned = entity.IsReturned,
				IsResellable = entity.IsResellable
			};
		}
		public static OrderItemReturnVM ToVM(this OrderItemReturnDto dto)
		{
			return new OrderItemReturnVM
			{
				Id = dto.Id,
				Index = dto.Index,
				OrderItemId = dto.OrderItemId,
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