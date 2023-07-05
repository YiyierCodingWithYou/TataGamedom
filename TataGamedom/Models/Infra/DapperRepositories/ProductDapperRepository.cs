using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.ViewModels.Products;

namespace TataGamedom.Models.Infra.DapperRepositories
{
	public class ProductDapperRepository : IProductRepository
	{
		private string _connStr;
		public ProductDapperRepository()
		{
			_connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		}

		public IEnumerable<ProductIndexVM> Get()
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT P.Id,P.[Index] AS [Index],G.ChiName AS GameName ,GPC.Name AS GamePlatformName,P.IsVirtual AS IsVirtual,P.Price AS Price,CONVERT(DATE,P.SaleDate)AS SaleDate,PSC.Name AS ProductStatus,BM.Name AS CreatedBackendMemberName,P.CreatedTime AS CreatedTime
FROM Products AS P
JOIN Games AS G ON P.GameId=G.Id
JOIN GamePlatformsCodes AS GPC ON GPC.Id = P.GamePlatformId
JOIN ProductStatusCodes AS PSC ON PSC.Id = P.ProductStatusId
JOIN BackendMembers AS BM ON BM.Id = P.CreatedBackendMemberId
ORDER BY G.Id";
				return conn.Query<ProductIndexVM>(sql);
			}
		}

		public ProductEditVM GetGameById(int id)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"select P.Id,G.Id AS GameId,P.[Index],G.ChiName AS GameName,G.Description,GPC.Id AS GamePlatform,P.IsVirtual,P.Price,P.SystemRequire,P.SaleDate,PSC.Id AS ProductStatus,BM.Name AS ModifiedBackendMemberName,P.ModifiedTime
from Products AS P
JOIN Games AS G ON G.Id = P.GameId
JOIN GamePlatformsCodes AS GPC ON GPC.Id = P.GamePlatformId
LEFT JOIN BackendMembers AS BM ON BM.Id = P.ModifiedBackendMemberId
JOIN ProductStatusCodes AS PSC ON PSC.Id = P.ProductStatusId
WHERE P.Id =@Id";
				return conn.QueryFirstOrDefault<ProductEditVM>(sql, new { Id = id });
			}
		}

		public bool Update(ProductEditVM vm)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"UPDATE Products SET [Index]=@Index, GamePlatformId=@GamePlatformId, IsVirtual = @IsVirtual, Price=@Price,SystemRequire=@SystemRequire,SaleDate=@SaleDate,ProductStatusId=@ProductStatusId,ModifiedBackendMemberId=@ModifiedBackendMemberId,ModifiedTime=@ModifiedTime WHERE Id = @Id";
				var rowAffected = conn.Execute(sql, new {
					Id = vm.Id,
					Index = vm.Index,
					GamePlatformId = vm.GamePlatform,
					IsVirtual = vm.IsVirtual,
					Price = vm.Price,
					SystemRequire = vm.SystemRequire,
					SaleDate = vm.SaleDate,
					ProductStatusId = vm.ProductStatus,
					ModifiedBackendMemberId = vm.ModifiedBackendMemberId,
					ModifiedTime = vm.ModifiedTime
				});
				return rowAffected > 0;
			}
		}

		public Product GetGameByGameIdAndGPId(ProductEditVM vm)
		{
			using(var conn = new SqlConnection(_connStr))
			{
				string sql = @"select*from Products WHERE GameId=@GameId AND GamePlatformId=@GamePlatformId;";
				return conn.QueryFirstOrDefault<Product>(sql, new { GameId = vm.GameId, GamePlatformId=vm.GamePlatform });
			}
		}
		public List<ProductEditImgVM> GetImgs(int id)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = "SELECT*FROM ProductImages WHERE ProductId = @ProductId";
				return conn.Query<ProductEditImgVM>(sql, new { ProductId = id }).ToList();
			}
		}
	}
}