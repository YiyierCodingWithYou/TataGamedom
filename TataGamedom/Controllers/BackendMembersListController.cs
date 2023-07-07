using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Filters;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.ViewModels.Members;
using TataGamedom.Models.ViewModels.News;

namespace TataGamedom.Controllers
{
    public class BackendMembersListController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private string _connstr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		// GET: BackendMembersList

		[AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
		public ActionResult Index()
        {
            using (var con = new SqlConnection(_connstr))
            {
                string sql = @"SELECT bm.Id ,bm.Name,bm.Account,bm.Email,bm.Phone,
bmr.Name as BackendMembersRoleName ,bm.ActiveFlag
FROM BackendMembers AS bm
LEFT JOIN BackendMembersRolesCodes AS bmr ON bmr.Id = bm.BackendMembersRoleId";

				var list = con.Query<BackendMembersListVM>(sql);

				return View(list);

			}
        }

		// GET: BackendMembersList/Details/5
		[AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackendMember backendMember = db.BackendMembers.Find(id);
            if (backendMember == null)
            {
                return HttpNotFound();
            }
            return View(backendMember);
        }

		// GET: BackendMembersList/Edit/5
		[AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var con = new SqlConnection(_connstr))
            {
                string sql = @"SELECT bm.Id, bm.Name, bm.Account,bm.BackendMembersRoleId, bm.Email, bm.Phone,
                bmr.Name AS BackendMembersRoleName, bm.ActiveFlag
                FROM BackendMembers AS bm
                LEFT JOIN BackendMembersRolesCodes AS bmr ON bmr.Id = bm.BackendMembersRoleId
                WHERE bm.Id = @Id";


                var list = con.Query<BackendMembersListVM>(sql, new { Id = id }).SingleOrDefault();

				if (list == null)
				{
					return HttpNotFound();
				}

				ViewBag.BackendMembersRoleId = new SelectList(db.BackendMembersRolesCodes, "Id", "Name", list.BackendMembersRoleId);

				return View(list);
			}
        }

        // POST: BackendMembersList/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BackendMembersListVM list)
        {
            if (ModelState.IsValid)
            {
                using (var con = new SqlConnection(_connstr))
                {
                    string sql = @"UPDATE BackendMembers
                   SET 
                       BackendMembersRoleId = @BackendMembersRoleId
                   WHERE Id = @Id";

                    con.Execute(sql, list);
                }
                return RedirectToAction("Index");
            }

            ViewBag.BackendMembersRoleId = new SelectList(db.BackendMembersRolesCodes, "Id", "Name", list.BackendMembersRoleId);
            return View(list);
        }


		//// GET: BackendMembersList/Delete/5
		//[AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
		//public ActionResult Delete(int? id)
  //      {
  //          if (id == null)
  //          {
  //              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
  //          }
  //          BackendMember backendMember = db.BackendMembers.Find(id);
  //          if (backendMember == null)
  //          {
  //              return HttpNotFound();
  //          }
  //          return View(backendMember);
  //      }

		//// POST: BackendMembersList/Delete/5
		//[AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
		//[HttpPost, ActionName("Delete")]
  //      [ValidateAntiForgeryToken]
  //      public ActionResult DeleteConfirmed(int id)
  //      {
  //          BackendMember backendMember = db.BackendMembers.Find(id);
  //          db.BackendMembers.Remove(backendMember);
  //          db.SaveChanges();
  //          return RedirectToAction("Index");
  //      }


		// GET: BackendMembersList/Create
		[AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
		public ActionResult Create()
		{
			ViewBag.BackendMembersRoleId = new SelectList(db.BackendMembersRolesCodes, "Id", "Name");
			return View();
		}

		// POST: BackendMembersList/Create
		[AuthorizeFilter(UserRole.Tataboss, UserRole.Memberstata)]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(BackendMembersListVM list)
		{
			if (ModelState.IsValid)
			{

				if (SameAccount(list.Account))
				{
					ModelState.AddModelError("Account", "帳號已存在，請更換帳號");
					ViewBag.BackendMembersRoleId = new SelectList(db.BackendMembersRolesCodes, "Id", "Name", list.BackendMembersRoleId);
					return View(list);
				}

				using (var con = new SqlConnection(_connstr))
				{
					string sql = @"INSERT INTO BackendMembers (Name, Account, Password, Birthday, Email, Phone, RegistrationDate, BackendMembersRoleId, ActiveFlag)
                           VALUES (@Name, @Account, @Password, @Birthday, @Email, @Phone, GETDATE(), @BackendMembersRoleId, 1);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                    //雜湊密碼
					var salt = HashUtility.GetSalt();
					var hashPwd = HashUtility.ToSHA256(list.Password, salt);

					var parameters = new
					{
						list.Name,
						list.Account,
						Password = hashPwd,
						list.Birthday,
						list.Email,
						list.Phone,
						list.BackendMembersRoleId
					};

					con.Query<int>(sql, parameters);

					ViewBag.BackendMembersRoleId = new SelectList(db.BackendMembersRolesCodes, "Id", "Name", list.BackendMembersRoleId);

					return RedirectToAction("Index");
				}

			}
			return View(list);
		}


		private bool SameAccount(string account)
		{
			using (var con = new SqlConnection(_connstr))
			{
				string sql = "SELECT COUNT(*) FROM BackendMembers WHERE Account = @Account";
				int count = con.ExecuteScalar<int>(sql, new { Account = account });
				return count > 0;
			}
		}

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
					string sql = @"UPDATE BackendMembers SET ActiveFlag = 0
WHERE Id = @Id";

					con.Execute(sql, new { BackendMemberId = backendMember.Id, Id = id });
				}
			}
			return RedirectToAction("Index");
		}



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
					string sql = @"UPDATE BackendMembers SET ActiveFlag = 1
WHERE Id = @Id";

					con.Execute(sql, new { BackendMemberId = backendMember.Id, Id = id });
				}
			}
			return RedirectToAction("Index");
		}


		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
