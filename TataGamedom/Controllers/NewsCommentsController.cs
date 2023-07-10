using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.ViewModels.News;
using Dapper;
using TataGamedom.Models.ViewModels.Members;
using TataGamedom.Filters;

namespace TataGamedom.Controllers
{
	public class NewsCommentsController : Controller
	{
		private string _connstr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		private AppDbContext db = new AppDbContext();

		// GET: NewsComments
		[AuthorizeFilter(UserRole.Tataboss, UserRole.Newstata)]
		public ActionResult Index(int? newsId)
		{
			using (var con = new SqlConnection(_connstr))
			{
				string sql = @"SELECT NC.Id ,M.Name as MemberName, NC.Time, NC.Content, NC.ActiveFlag, N.Title as Title
FROM NewsComments AS NC
JOIN Members AS M ON M.Id = NC.MemberID
JOIN News AS N ON N.Id = NC.NewsId
";

				if (newsId.HasValue)
				{
					sql += " WHERE N.Id = @NewsId";
					var newsComments = con.Query<NewsCommentIndexVM>(sql, new { NewsId = newsId.Value });
					return View(newsComments);
				}
				else
				{
					var newsComments = con.Query<NewsCommentIndexVM>(sql);
					return View(newsComments);
				}
			}
		}
		[AuthorizeFilter(UserRole.Tataboss, UserRole.Newstata)]
		public ActionResult Details(int? id)
		{
			using (var con = new SqlConnection(_connstr))
			{
				string sql = @"SELECT NC.Id, M.Name as MemberName, NC.Time, NC.Content, NC.ActiveFlag, N.Title as Title
FROM NewsComments AS NC
JOIN Members AS M ON M.Id = NC.MemberID
JOIN News AS N ON N.Id = NC.NewsId
WHERE NC.Id = @Id";

				var detials = con.Query<NewsCommentIndexVM>(sql, new { Id = id }).SingleOrDefault();

				return View(detials);
			}
		}


		[AuthorizeFilter(UserRole.Tataboss, UserRole.Newstata)]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
			var currentUserAccount = User.Identity.Name;
			var backendMember = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

			if (backendMember != null)
			{
				using (var con = new SqlConnection(_connstr))
				{
					string sql = @"UPDATE NewsComments SET ActiveFlag = 0, DeleteDatetime = GETDATE(), DeleteBackendMemberId = @BackendMemberId WHERE Id = @Id";

					con.Execute(sql, new { BackendMemberId = backendMember.Id, Id = id });
				}
			}
			return RedirectToAction("Index");
		}


		[AuthorizeFilter(UserRole.Tataboss, UserRole.Newstata)]
		[HttpPost, ActionName("Reduction")]
		[ValidateAntiForgeryToken]
		public ActionResult Reduction(int id)
		{
			var currentUserAccount = User.Identity.Name;
			var backendMember = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

			if (backendMember != null)
			{
				using (var con = new SqlConnection(_connstr))
				{
					string sql = @"UPDATE NewsComments SET ActiveFlag = 1, DeleteDatetime = NULL, DeleteBackendMemberId = NULL WHERE Id = @Id";

					con.Execute(sql, new { BackendMemberId = backendMember.Id, Id = id });
				}
			}
			return RedirectToAction("Index");
		}


	}
}