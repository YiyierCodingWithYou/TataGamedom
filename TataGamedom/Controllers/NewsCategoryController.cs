using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;

namespace TataGamedom.Controllers
{
    public class NewsCategoryController : Controller
    {
        private AppDbContext db = new AppDbContext();
		[Authorize]
		// GET: NewsCategory
		public ActionResult Index()
        {
            return View(db.NewsCategoryCodes.ToList());
        }
		[Authorize]
		// GET: NewsCategory/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategoryCode newsCategoryCode = db.NewsCategoryCodes.Find(id);
            if (newsCategoryCode == null)
            {
                return HttpNotFound();
            }
            return View(newsCategoryCode);
        }
		[Authorize]
		// GET: NewsCategory/Create
		public ActionResult Create()
        {
            return View();
        }

		// POST: NewsCategory/Create
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] NewsCategoryCode newsCategoryCode)
        {
			if (ModelState.IsValid)
			{
				// 檢查是否有重複的名稱
				if (db.NewsCategoryCodes.Any(nc => nc.Name == newsCategoryCode.Name))
				{
					ModelState.AddModelError("", "名稱已存在，請使用其他名稱。");
					return View(newsCategoryCode);
				}

				db.NewsCategoryCodes.Add(newsCategoryCode);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(newsCategoryCode);
        }

		// GET: NewsCategory/Edit/5
		[Authorize]
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategoryCode newsCategoryCode = db.NewsCategoryCodes.Find(id);
            if (newsCategoryCode == null)
            {
                return HttpNotFound();
            }
            return View(newsCategoryCode);
        }

		// POST: NewsCategory/Edit/5
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] NewsCategoryCode newsCategoryCode)
        {
            if (ModelState.IsValid)
            {
				if (db.NewsCategoryCodes.Any(nc => nc.Id != newsCategoryCode.Id && nc.Name == newsCategoryCode.Name))
				{
					ModelState.AddModelError("", "名稱已存在，請使用其他名稱。");
					return View(newsCategoryCode);
				}

				db.Entry(newsCategoryCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsCategoryCode);
        }

		// GET: NewsCategory/Delete/5
		[Authorize]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsCategoryCode newsCategoryCode = db.NewsCategoryCodes.Find(id);
            if (newsCategoryCode == null)
            {
                return HttpNotFound();
            }
            return View(newsCategoryCode);
        }

		// POST: NewsCategory/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsCategoryCode newsCategoryCode = db.NewsCategoryCodes.Find(id);

			if (newsCategoryCode == null)
			{
				return HttpNotFound();
			}

			// 檢查是否存在關聯鍵
			if (HasAssociatedRecords(newsCategoryCode))
			{
                //ModelState.AddModelError("", "無法刪除該記錄，因為它與其他資料有關聯。");
                //return View("Delete", newsCategoryCode);
                TempData["ErrorMessage"] = "無法刪除該記錄，因為它與其他資料有關聯。";
                return RedirectToAction("DELETE");
            }


			db.NewsCategoryCodes.Remove(newsCategoryCode);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		private bool HasAssociatedRecords(NewsCategoryCode newsCategoryCode)
		{
			// 檢查是否存在關聯鍵的邏輯
			// 你需要根據你的資料庫結構和關聯性定義進行判斷
			// 在這裡，你可以查詢相關的資料表或使用其他方式來判斷是否存在關聯鍵

    
			bool hasAssociations = db.News.Any(n => n.NewsCategoryId == newsCategoryCode.Id);

			return hasAssociations;
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
