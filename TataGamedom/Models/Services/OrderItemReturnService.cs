using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TataGamedom.Models.Dtos.OrderItemReturns;
using TataGamedom.Models.Dtos.Orders;
using TataGamedom.Models.Dtos.StockInSheets;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
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

        /// <summary>
        /// 同步改變訂單狀態 => 退貨程序處理中
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Result Create(OrderItemReturnDto dto)
        {
            int maxId = _repo.GetMaxIdInDb();
            var indexGenerator = new IndexGenerator(maxId);

            string orderIndex = _repo.GetReturnedOrderIndex(dto.OrderItemId);
            dto.Index = indexGenerator.GetOrderItemReturnIndex(dto, orderIndex);
            _repo.Create(dto);

            OrderItem orderItem = GetOrderItem(dto);
            ChangeOrderStatus(orderItem);
            return Result.Success();
        }
        private OrderItem GetOrderItem(OrderItemReturnDto dto)
        {
            var db = new AppDbContext();
            return db.OrderItems.SingleOrDefault(item => item.Id == dto.OrderItemId);
        }

        private void ChangeOrderStatus(OrderItem orderItem)
        {
            
            IOrderRepository repo = new OrderRepository();
            OrderService service = new OrderService(repo);
            OrderDto dto = service.GetById(orderItem.OrderId);
            dto.OrderStatusId = 4;
            service.Update(dto);
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
