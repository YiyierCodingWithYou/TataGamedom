using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using TataGamedom.Models.Dtos.Reports;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.ViewModels.Reports;

namespace TataGamedom.Controllers.Api
{
	public class ReportsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();
		private string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString(); //forDapper
		private SimpleHelper simpleHelper = new SimpleHelper();

		// GET: api/ReportsApi
		public IEnumerable<ReportListVm> GetReports()
		{
			using (var connection = new SqlConnection(_connStr))
			{
				connection.Open();

				string query = @"
                    SELECT
                    N'貼文檢舉' as [Type],
                    pr.Id as ReportId,
                    concat('PR',pr.Id ) as [Index],
                    pr.Reason,
                    pr.Datetime,
                    m.Account,
                    p.BoardId,
                    bd.Name as BoardName,
                    p.Id as [ReportedId],
                    p.Id as [PostId],
                    p.Content as ReportedContent,
                    p.ActiveFlag as ReportedContentStatus,
                    p.Account as ReportedAccount,
                    pr.IsCommit as IsCommit,
                    CASE pr.IsCommit 
	                    WHEN 1 THEN N'完成'
	                    WHEN 0 THEN N'待確認'
                    END AS IsCommitText,
                    bm.Account as ReviewerBackendMemberAccount,
                    pr.ReviewComment,
                    pr.ReviewDatetime
                    FROM PostReports as pr
                    left join Members as m on pr.MemberID = m.Id
                    left join BackendMembers as bm on pr.ReviewerBackenMemberId = bm.Id
                    left join (Select p.Id, p.BoardId, p.Content, p.Datetime, p.ActiveFlag, m.Account from Posts as p left join members as m on p.memberId= m.Id ) as p on pr.PostId = p.Id
                    left join boards as bd on p.BoardId = bd.Id

                    union all

                    SELECT
                    N'留言檢舉' as [Type],
                    cr.Id as ReportId,
                    concat('CR',cr.Id ) as [Index],
                    cr.Reason,
                    cr.Datetime,
                    m.Account,
                    c.BoardId,
                    bd.Name as BoardName,
                    c.Id as [ReportedId],
                    c.PostId,
                    c.Content as ReportedContent,
                    c.ActiveFlag as ReportedContentStatus,
                    c.Account as ReportedAccount,
                    cr.IsCommit as IsCommit,
                    CASE cr.IsCommit 
	                    WHEN 1 THEN N'完成'
	                    WHEN 0 THEN N'待確認'
                    END AS IsCommitText,
                    bm.Account as ReviewerBackendMemberAccount,
                    cr.ReviewComment,
                    cr.ReviewDatetime
                    FROM PostCommentReports as cr
                    left join Members as m on cr.MemberID = m.Id
                    left join BackendMembers as bm on cr.ReviewerBackenMemberId = bm.Id
                    left join (Select p.boardid, pc.Id, pc.PostId, pc.Content, pc.Datetime, pc.ActiveFlag, m.Account from PostComments as pc left join members as m on pc.memberId= m.Id left join posts as p on pc.PostId= p.Id ) as c on cr.PostCommentId = c.Id
					left join posts as p on c.PostId = p.Id
                    left join boards as bd on p.BoardId = bd.Id

				Order by
					Datetime desc

        ";
				IEnumerable<ReportListVm> result = connection.Query<ReportListVm>(query);
				return result;
			}

		}

		// PUT: api/ReportsApi/5/Post
		[System.Web.Http.HttpPut]
		[System.Web.Http.Route("api/ReportsApi/{id}/Post")]
		[ResponseType(typeof(ApiResult))]
		public ApiResult PutPostReport(int id, ReportsConfirmVm vm)
		{
			var backendMemberAccount = User.Identity.Name;
			int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);
			//int backendMemberId = 1;
			//if (!ModelState.IsValid)
			//{
			//	return ApiResult.Fail("驗證失敗");
			//}
			if (id != vm.Id)
			{
				return ApiResult.Fail("不對喔");
			}
			PostReport existReport = db.PostReports.Find(id);
			if (existReport == null)
			{
				return ApiResult.Fail("找不到喔");
			}
			if(existReport.IsCommit) 
			{
				return ApiResult.Fail("早就確認過哩 我是P");
			}
			ReportsConfirmDto dto = new ReportsConfirmDto
			{
				ReviewComment = vm.ReviewComment
			};
			try
			{
				existReport.ReviewDatetime = DateTime.Now;
				existReport.ReviewerBackenMemberId = backendMemberId;
				existReport.ReviewComment = dto.ReviewComment;
				existReport.IsCommit = true;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("資料庫改不了" + ex.Message);
			}
			return ApiResult.Success("確認成功！");
		}

		// PUT: api/ReportsApi/5/Comment
		[System.Web.Http.HttpPut]
		[System.Web.Http.Route("api/ReportsApi/{id}/Comment")]
		[ResponseType(typeof(ApiResult))]
		public ApiResult PutCommentReport(int id, ReportsConfirmVm vm)
		{
			var backendMemberAccount = User.Identity.Name;
			int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);
			//int backendMemberId = 1;
			//if (!ModelState.IsValid)
			//{
			//	return ApiResult.Fail("驗證失敗");
			//}
			if (id != vm.Id)
			{
				return ApiResult.Fail("不對喔");
			}
			PostCommentReport existReport = db.PostCommentReports.Find(id);
			if (existReport == null)
			{
				return ApiResult.Fail("找不到喔");
			}
			if (existReport.IsCommit)
			{
				return ApiResult.Fail("早就確認過哩 我是C");
			}
			ReportsConfirmDto dto = new ReportsConfirmDto
			{
				ReviewComment = vm.ReviewComment
			};
			try
			{
				existReport.ReviewDatetime = DateTime.Now;
				existReport.ReviewerBackenMemberId = backendMemberId;
				existReport.ReviewComment = dto.ReviewComment;
				existReport.IsCommit = true;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("資料庫改不了" + ex.Message);
			}
			return ApiResult.Success("確認成功！");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool PostReportExists(int id)
		{
			return db.PostReports.Count(e => e.Id == id) > 0;
		}
	}
}


// GET: api/ReportsApi/5
//[ResponseType(typeof(PostReport))]
//public IHttpActionResult GetPostReport(int id)
//{

//    PostReport postReport = db.PostReports.Find(id);
//    if (postReport == null)
//    {
//        return NotFound();
//    }

//    return Ok(postReport);
//}

// POST: api/ReportsApi
//[ResponseType(typeof(PostReport))]
//public IHttpActionResult PostPostReport(PostReport postReport)
//{
//	if (!ModelState.IsValid)
//	{
//		return BadRequest(ModelState);
//	}

//	db.PostReports.Add(postReport);
//	db.SaveChanges();

//	return CreatedAtRoute("DefaultApi", new { id = postReport.Id }, postReport);
// DELETE: api/ReportsApi/5
//[ResponseType(typeof(PostReport))]
//public IHttpActionResult DeletePostReport(int id)
//{
//	PostReport postReport = db.PostReports.Find(id);
//	if (postReport == null)
//	{
//		return NotFound();
//	}

//	db.PostReports.Remove(postReport);
//	db.SaveChanges();

//	return Ok(postReport);
//}

