using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TataGamedom.Models.Dtos.OrderItemReturns;

namespace TataGamedom.Models.Interfaces
{
	public interface IOrderItemReturnRepository
	{
		IEnumerable<OrderItemReturnIndexDto> Search();

		void Create(OrderItemReturnDto dto);

		IEnumerable<OrderItemReturnDetailDto> GetByIndex(string orderIndex);

		OrderItemReturnDto GetById(int? id);

		void Update(OrderItemReturnDto dto);

		void Delete(int? id);

		int GetMaxIdInDb();
		string GetReturnedOrderIndex(int? orderItemId);

	}
}