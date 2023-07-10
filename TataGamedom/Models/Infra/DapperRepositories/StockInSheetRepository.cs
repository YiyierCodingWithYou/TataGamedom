using Antlr.Runtime.Tree;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TataGamedom.Models.Dtos.StockInSheets;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Interfaces;

namespace TataGamedom.Models.Infra.DapperRepositories
{
	public class StockInSheetRepository : IStockInSheetRepository
	{
		private string Connstr => System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		public void Create(StockInSheetDto dto)
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"
INSERT INTO StockInSheets
([Index], [StockInStatusId], [SupplierId], [Quantity], [OrderRequestDate], 
[ArrivedAt])
VALUES 
(@Index, @StockInStatusId, @SupplierId, @Quantity, @OrderRequestDate, @ArrivedAt)";

				connection.Execute(sql, dto);
			}
		}
		public int GetMaxIdInDb()
		{
			using (var connection = new SqlConnection(Connstr))
			{
				string sql = "SELECT MAX(Id) FROM StockInSheets";
				int maxId = connection.QuerySingle<int>(sql);

				return maxId;
			}
		}

		public IEnumerable<StockInSheetIndexDto> Search()
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"
SELECT 
SIS.[Index], SIS.OrderRequestDate, SIS.ArrivedAt, SIS.Quantity, SISC.[Name] AS StockInStatusCodeName,
S.[Name] AS SupplierName, SIS.Id
FROM StockInSheets AS SIS
JOIN StockInStatusCodes AS SISC ON SIS.StockInStatusId = SISC.Id 
JOIN Suppliers AS S ON SIS.SupplierId = S.Id
ORDER BY SISC.Id, SIS.OrderRequestDate DESC
";
				var stockInSheet = connection.Query<StockInSheetIndexDto>(sql);
				return stockInSheet;
			}
		}

		public StockInSheetDto GetById(int? id)
		{
			using (var connection = new SqlConnection(Connstr))
			{
				string sql = @"SELECT * FROM StockInSheets WHERE [Id] = @id";
				var stockInSheet = connection.QuerySingleOrDefault<StockInSheet>(sql, new { Id = id });
				return stockInSheet.ToDto();
			}
		}

		public void Update(StockInSheetDto dto)
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"
UPDATE StockInSheets SET
[StockInStatusId] = @StockInStatusId , [SupplierId]= @SupplierId, [Quantity]= @Quantity, [OrderRequestDate]= @OrderRequestDate, [ArrivedAt] = @ArrivedAt
WHERE Id = @id";

				connection.ExecuteScalar(sql, dto);
			}
		}

		public int CallAutoOrder(IEnumerable<StockInSheetDto> stockInSheetsByAutoOrder)
		{
			using (var connection = new SqlConnection(Connstr))
			{
				connection.Open();
				using (var trans = connection.BeginTransaction())
				{
					string sql = @"INSERT INTO StockInSheets
([Index], [StockInStatusId], [SupplierId], [Quantity], [OrderRequestDate])
VALUES 
(@Index, @StockInStatusId , @SupplierId, @Quantity, @OrderRequestDate";

					var executeResult = connection.Execute(sql, stockInSheetsByAutoOrder, trans);
					trans.Commit();
					return executeResult;
				}
			}
		}

		public int GetAutoOrderSupplierId(int? productId)
		{
			using (var connection = new SqlConnection(Connstr)) 
			{
				string sql = @"SELECT S.Id
FROM InventoryItems AS II
JOIN StockInSheets AS SIS ON II.StockInSheetId = SIS.Id
JOIN Suppliers AS S ON SIS.SupplierId = S.Id

WHERE SIS.OrderRequestDate >= DATEADD(YEAR, -1, GETDATE())

AND II.ProductId = @productId

GROUP BY S.Id
HAVING SUM(Quantity) = (SELECT MAX(Total)FROM (SELECT SUM(Quantity) AS Total
FROM InventoryItems AS II
JOIN StockInSheets AS SIS ON II.StockInSheetId = SIS.Id
JOIN Suppliers AS S ON SIS.SupplierId = S.Id
WHERE SIS.OrderRequestDate >= DATEADD(YEAR, -1, GETDATE())
AND II.ProductId = 1
GROUP BY S.[Name], S.Id) AS Subquery)
";

				return connection.QueryFirstOrDefault(sql, new {ProductId = productId });
			}
		}

		public List<int> GetProductIdNeedAutoOrder()
		{
			var productIdNeedAutoOrder = new List<int>();

			using (var connection = new SqlConnection()) 
			{
				string sql = @"
SELECT
P.Id AS ProductId FROM InventoryItems AS IIT
RIGHT JOIN Products AS P ON IIT.ProductId = P.Id
FULL JOIN StandardProducts AS SP ON SP.ProductId = P.Id
RIGHT JOIN Games AS G ON P.GameId = G.Id

WHERE 
(SELECT COUNT(*) FROM OrderItems AS OI RIGHT JOIN InventoryItems AS II 
ON OI.InventoryItemId = II.Id WHERE II.ProductId = P.Id AND OI.ProductId IS NULL)= 0

AND SP.[AutoOrder] = 1

GROUP BY
P.Id, SP.[AutoOrder]";
				foreach (int id in connection.Query(sql)) 
				{
					productIdNeedAutoOrder.Add(id);
				};
				return productIdNeedAutoOrder;
			}
		}
	}
}