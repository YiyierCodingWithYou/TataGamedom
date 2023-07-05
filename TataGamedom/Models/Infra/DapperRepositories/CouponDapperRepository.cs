using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.ViewModels.Coupons;

namespace TataGamedom.Models.Infra.DapperRepositories
{
	public class CouponDapperRepository : ICouponRepository
	{
		private string _connStr;
		public CouponDapperRepository()
		{
			_connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		}

		public bool Create(CouponCreateVM vm)
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"INSERT INTO Coupons (Name, Discount, DiscountTypeId, Description, CreatedTime, CreatedBackendMemberId, Threshold, StartTime, EndTime, ActiveFlag)
VALUES(@Name, @Discount, @DiscountTypeId, @Description, @CreatedTime, @CreatedBackendMemberId, @Threshold, @StartTime, @EndTime, @ActiveFlag)";
				var rowAffected = conn.Execute(sql,vm);
				return rowAffected > 0;
			}
		}

		public IEnumerable<CouponIndexVM> Get()
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT C.Id AS CouponId,C.Name,C.Description,C.Threshold,C.StartTime,C.EndTime,C.ActiveFlag,BM.Name AS CreatedBackendMemberName,C.CreatedTime
FROM Coupons AS C
JOIN BackendMembers AS BM ON BM.Id = C.CreatedBackendMemberId";
				return conn.Query<CouponIndexVM>(sql);
			}
		}
	}
}