using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.ViewModels.BucketLogs;
using TataGamedom.Models.ViewModels.PostsComments;

namespace TataGamedom.Controllers.Api
{
	public class BucketLogsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();
		private string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString(); //forDapper
		private SimpleHelper simpleHelper = new SimpleHelper();

		// GET: api/BucketLogsApi
		public IEnumerable<BucketLogListVm> GetBucketLogs()
		{
			using (var connection = new SqlConnection(_connStr))
			{
				connection.Open();

				string query = @"
      SELECT
        bl.Id,
        m.Account,
        CASE
            WHEN bl.ModeratorMemberId IS NOT NULL THEN 'Moderator'
            WHEN bl.BackendMmemberId IS NOT NULL THEN 'Staff'
            ELSE ''
        END AS ActionType,
        CASE
			WHEN bl.ModeratorMemberId IS NOT NULL THEN COALESCE(mm.Account, '')
			WHEN bl.BackendMmemberId IS NOT NULL THEN COALESCE(bm.Account, '')
			ELSE ''
        END AS ActionAccount,
        b.Name,
        bl.BucketReason,
        bl.StartTime,
        bl.EndTime,
        CASE
            WHEN bl.IsNoctified = 1 THEN N'已通知'
            ELSE N'未通知'
        END AS IsNoticedText,
		CASE
			WHEN bl.EndTime >= GETDATE() THEN N'水桶中'
			ELSE N'已結束'
		END AS BucketStatus
    FROM
        BucketLogs bl
        JOIN Members m ON m.Id = bl.BucketMemberId
		LEFT JOIN Members mm on mm.Id = bl.ModeratorMemberId
		LEFT JOIN BackendMembers bm on bm.Id = bl.BackendMmemberId
        LEFT JOIN Boards b ON b.Id = bl.BoardId

	Order by StartTime desc
";
				IEnumerable<BucketLogListVm> result = connection.Query<BucketLogListVm>(query);
				return result;
			}
		}


		// GET: api/BucketLogsApi/CheckBucketStatus
		[HttpGet]
		[Route("api/BucketLogsApi/CheckBucketStatus")]
		public bool CheckBucketStatus(string boardName, string memberAccount)
		{
			int bucketMemberId = simpleHelper.memberIdByAccount(memberAccount);
			int boardId = simpleHelper.boardIdByName(boardName);

			bool hasActiveBucketLogs = db.BucketLogs.Any(bl =>
				bl.BucketMemberId == bucketMemberId &&
				bl.BoardId == boardId &&
				bl.EndTime > DateTime.Now
			);

			return hasActiveBucketLogs;
		}
		//GET: /api/CheckBucketStatus?boardName=BoardNameValue&memberAccount=MemberAccountValue



		// POST: api/BucketLogsApi
		[ResponseType(typeof(ApiResult))]
		public ApiResult PostBucketLog(BucketLogsAddVm vm)
		{
			var backendMemberAccount = User.Identity.Name;
			//int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);
			int backendMemberId = 1;
			int bucketMemberId = simpleHelper.memberIdByAccount(vm.BucketMemberAccount);
			int boardId = simpleHelper.boardIdByName(vm.BoardName);

			bool hasActiveBucketLogs = db.BucketLogs.Any(bl =>
			bl.BucketMemberId == bucketMemberId &&
			bl.EndTime > DateTime.Now
			);

			if (hasActiveBucketLogs)
			{
				return ApiResult.Fail("早就被水桶啦");
			}

			// 根據 BucketLogsAddVm 建立新的 BucketLogs 物件
			BucketLog bucketLog = new BucketLog
			{
				Id = vm.Id,
				BucketMemberId = bucketMemberId,
				ModeratorMemberId = null, // 尚未設定
				BackendMmemberId = backendMemberId,
				BoardId = boardId,
				BucketReason = vm.BucketReason,
				StartTime = DateTime.Now,
				EndTime = DateTime.Now.AddDays(vm.Days).Date.AddDays(1).AddSeconds(-1), //隔幾日後的 23:59 分
				IsNoctified = false // 預設為未通知
			};

			try
			{
				db.BucketLogs.Add(bucketLog);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("新增失敗：" + ex.Message);
			}

			return ApiResult.Success("新增成功");
		}
		// DELETE: api/BucketLogsApi/5
		[ResponseType(typeof(BucketLog))]
		public ApiResult DeleteBucketLog(int id)
		{

			BucketLog entity = db.BucketLogs.Find(id);

			if (entity == null)
			{

				return ApiResult.Fail("刪除失敗");
			}

			if (entity.EndTime <= DateTime.Now)
			{
				return ApiResult.Fail("早就已結束水桶啦");
			}

			try
			{
				entity.EndTime = DateTime.Now;
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("解除水桶失敗：" + ex.Message);
			}

			return ApiResult.Success("解除水桶成功");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool BucketLogExists(int id)
		{
			return db.BucketLogs.Count(e => e.Id == id) > 0;
		}
	}

	// GET: api/BucketLogsApi/5
	//[ResponseType(typeof(BucketLog))]
	//public IHttpActionResult GetBucketLog(int id)
	//{
	//	BucketLog bucketLog = db.BucketLogs.Find(id);
	//	if (bucketLog == null)
	//	{
	//		return NotFound();
	//	}

	//	return Ok(bucketLog);
	//}

	// PUT: api/BucketLogsApi/5
	//[ResponseType(typeof(void))]
	//public IHttpActionResult PutBucketLog(int id, BucketLog bucketLog)
	//{
	//	if (!ModelState.IsValid)
	//	{
	//		return BadRequest(ModelState);
	//	}

	//	if (id != bucketLog.Id)
	//	{
	//		return BadRequest();
	//	}

	//	db.Entry(bucketLog).State = EntityState.Modified;

	//	try
	//	{
	//		db.SaveChanges();
	//	}
	//	catch (DbUpdateConcurrencyException)
	//	{
	//		if (!BucketLogExists(id))
	//		{
	//			return NotFound();
	//		}
	//		else
	//		{
	//			throw;
	//		}
	//	}

	//	return StatusCode(HttpStatusCode.NoContent);
	//}



}