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
    public class StandardProductsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: StandardProducts
        public ActionResult Index()
        {
            var standardProducts = db.StandardProducts.Include(s => s.Product);
            return View(standardProducts.ToList());
        }

        // GET: StandardProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardProduct standardProduct = db.StandardProducts.Find(id);
            if (standardProduct == null)
            {
                return HttpNotFound();
            }
            return View(standardProduct);
        }

        // GET: StandardProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Index");
            return View();
        }

        // POST: StandardProducts/Create
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,AutoOrder,Quantity")] StandardProduct standardProduct)
        {
            if (ModelState.IsValid)
            {
                db.StandardProducts.Add(standardProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Index", standardProduct.ProductId);
            return View(standardProduct);
        }

        // GET: StandardProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardProduct standardProduct = db.StandardProducts.Find(id);
            if (standardProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Index", standardProduct.ProductId);
            return View(standardProduct);
        }

        // POST: StandardProducts/Edit/5
        // 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,AutoOrder,Quantity")] StandardProduct standardProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standardProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Index", standardProduct.ProductId);
            return View(standardProduct);
        }

        // GET: StandardProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardProduct standardProduct = db.StandardProducts.Find(id);
            if (standardProduct == null)
            {
                return HttpNotFound();
            }
            return View(standardProduct);
        }

        // POST: StandardProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StandardProduct standardProduct = db.StandardProducts.Find(id);
            db.StandardProducts.Remove(standardProduct);
            db.SaveChanges();
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
