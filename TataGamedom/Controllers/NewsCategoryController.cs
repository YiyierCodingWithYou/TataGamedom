using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.ViewModels.News;

namespace TataGamedom.Controllers
{
    public class NewsCategoryController : Controller
    {
        private AppDbContext db = new AppDbContext();
		[Authorize]
		// GET: NewsCategory
		public ActionResult Index()
		{
			var newsCategories = db.NewsCategoryCodes.ToList().Select(nc => new NewsCategoryVM
			{
				Id = nc.Id,
				Name = nc.Name
			});

			return View(newsCategories);
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
		public ActionResult Create([Bind(Include = "Name")] NewsCategoryVM newsCategoryVM)
		{
			if (ModelState.IsValid)
			{
				if (db.NewsCategoryCodes.Any(nc => nc.Name == newsCategoryVM.Name))
				{
					ModelState.AddModelError("", "名稱已存在，請使用其他名稱。");
					return View(newsCategoryVM);
				}

				NewsCategoryCode newsCategoryCode = new NewsCategoryCode
				{
					Name = newsCategoryVM.Name
				};
				TempData["SuccessMessage"] = $"成功新增{newsCategoryCode.Name}。";
				db.NewsCategoryCodes.Add(newsCategoryCode);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(newsCategoryVM);
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

			NewsCategoryVM newsCategoryVM = new NewsCategoryVM
			{
				Id = newsCategoryCode.Id,
				Name = newsCategoryCode.Name
			};

			return View(newsCategoryVM);
		}

		// POST: NewsCategory/Edit/5
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] NewsCategoryVM newsCategoryVM)
		{
			if (ModelState.IsValid)
			{
				NewsCategoryCode newsCategoryCode = db.NewsCategoryCodes.Find(newsCategoryVM.Id);
				if (newsCategoryCode == null)
				{
					return HttpNotFound();
				}

				if (db.NewsCategoryCodes.Any(nc => nc.Id != newsCategoryCode.Id && nc.Name == newsCategoryVM.Name))
				{
					ModelState.AddModelError("", "名稱已存在，請使用其他名稱。");
					return View(newsCategoryVM);
				}

				newsCategoryCode.Name = newsCategoryVM.Name;

				db.Entry(newsCategoryCode).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(newsCategoryVM);
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

			NewsCategoryVM newsCategory = new NewsCategoryVM
			{
				Id = newsCategoryCode.Id,
				Name = newsCategoryCode.Name
			};

			return View(newsCategory);
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
				TempData["ErrorMessage"] = $"無法刪除{newsCategoryCode.Name}，請聯繫工程師。";
				return RedirectToAction("Index");
			}
			else
			{
				db.NewsCategoryCodes.Remove(newsCategoryCode);
				db.SaveChanges();
				TempData["SuccessMessage"] = $"成功刪除{newsCategoryCode.Name}。";
			
			}
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
