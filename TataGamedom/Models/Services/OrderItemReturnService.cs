using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TataGamedom.Models.Dtos.OrderItemReturns;
using TataGamedom.Models.Dtos.StockInSheets;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Interfaces;

namespace TataGamedom.Models.Services
{
	public class OrderItemReturnService
	{
		private readonly IOrderItemReturnRepository _repo;
        public OrderItemReturnService(IOrderItemReturnRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<OrderItemReturnIndexDto> Search() => _repo.Search();

        public Result Create(OrderItemReturnDto dto)
        {
            int maxId = _repo.GetMaxIdInDb();
            var indexGenerator = new IndexGenerator(maxId);

            string orderIndex = _repo.GetReturnedOrderIndex(dto.OrderItemId);
            dto.Index = indexGenerator.GetOrderItemReturnIndex(dto, orderIndex);
            _repo.Create(dto);
            
            return Result.Success();
        }

		public IEnumerable<OrderItemReturnDetailDto> GetByIndex(string orderIndex) => _repo.GetByIndex(orderIndex);

		public OrderItemReturnDto GetById(int? id) => _repo.GetById(id);

		public Result Update(OrderItemReturnDto dto)
		{
			_repo.Update(dto);
			return Result.Success();
		}

        public Result Delete(int? id) 
        {
			_repo.Delete(id);
			return Result.Success();
		}

	}
}
