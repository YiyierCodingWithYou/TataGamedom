using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TataGamedom.Models.Dtos.InventoryItems;
using TataGamedom.Models.Dtos.OrderItemReturns;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Interfaces;

namespace TataGamedom.Models.Infra.DapperRepositories
{
	public class OrderItemReturnRepository : IOrderItemReturnRepository
	{
		private string Connstr => System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();

		public IEnumerable<OrderItemReturnIndexDto> Search()
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"
SELECT 
OIR.[Index], O.[Index] AS OrderIndex, OI.[Index] AS OrderItemIndex, OIR.IssuedAt, OIR.CompletedAt,
OIR.IsRefunded, OIR.IsReturned, OIR.IsResellable, OIR.Id
FROM OrderItemReturns AS OIR
JOIN OrderItems AS OI ON OIR.OrderItemId = OI.Id
JOIN Orders AS O ON OI.OrderId = O.Id
ORDER BY OrderIndex, OIR.[Index], OIR.IsReturned DESC, OIR.IssuedAt, OIR.IsRefunded 
";
				return connection.Query<OrderItemReturnIndexDto>(sql);
			}
		}

		public void Create(OrderItemReturnDto dto)
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"
INSERT INTO OrderItemReturns
([Index],[OrderItemId],[Reason],[IssuedAt],[CompletedAt],
[IsRefunded],[IsReturned],[IsResellable])
VALUES
(@Index, @OrderItemId, @Reason, @IssuedAt, @CompletedAt,
@IsRefunded, @IsReturned, @IsResellable)";

				connection.Execute(sql, dto);
			}
		}

		public int GetMaxIdInDb()
		{
			using (var connection = new SqlConnection(Connstr))
			{
				string sql = "SELECT MAX(Id) FROM OrderItemReturns";
				int maxId = connection.QuerySingle<int>(sql);

				return maxId;
			}
		}

		public IEnumerable<OrderItemReturnDetailDto> GetByIndex(string orderIndex)
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"
SELECT
OIR.[Index], O.[Index] AS OrderIndex, OI.[Index] AS OrderItemIndex, OI.ProductPrice AS OrderItemProductPrice, IIT.[Index] AS InventoryItemIndex,
OIR.Reason, OIR.IssuedAt,OIR.CompletedAt, OIR.IsRefunded, OIR.IsReturned, 
OIR.IsResellable, OIR.Id
FROM OrderItemReturns AS OIR
JOIN OrderItems AS OI ON OIR.OrderItemId = OI.Id
JOIN Orders AS O ON OI.OrderId = O.Id
JOIN InventoryItems AS IIT ON OI.InventoryItemId = IIT.Id
WHERE O.[Index] = @orderIndex";

				return connection.Query<OrderItemReturnDetailDto>(sql, new { OrderIndex = orderIndex });
			}
		}

		public OrderItemReturnDto GetById(int? id)
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"SELECT * FROM OrderItemReturns WHERE Id = @id";
				return connection.QuerySingleOrDefault<OrderItemReturnDto>(sql, new { Id = id });
			}
		}

		public void Update(OrderItemReturnDto dto)
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"
UPDATE OrderItemReturns SET
[OrderItemId] = @OrderItemId, [Reason] = @Reason, [IssuedAt]= @IssuedAt, [CompletedAt]= @CompletedAt, [IsRefunded] = @IsRefunded,
[IsReturned] = @IsReturned, [IsResellable] = @IsResellable
WHERE Id = @Id";

				connection.ExecuteScalar(sql, dto);
			}
		}

		public void Delete(int? id)
		{
			using (var connection = new SqlConnection(Connstr))
			{
				string sql = @"DELETE OrderItemReturns WHERE Id = @Id";

				connection.ExecuteScalar(sql, new {Id = id});
			}
		}

		public string GetReturnedOrderIndex(int? orderItemId)
		{
			using (var connection = new SqlConnection(Connstr))
			{
				string sql = @"
SELECT O.[Index] FROM OrderItems AS OI JOIN Orders AS O ON OI.OrderId = O.Id
WHERE OI.Id = @orderItemId ";

				return connection.QuerySingleOrDefault<Order>(sql, new {OrderItemId = orderItemId }).Index;
			}
		}

		
	}
}