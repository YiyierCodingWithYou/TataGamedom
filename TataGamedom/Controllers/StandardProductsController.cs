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

        public ActionResult Index()
        {
            var standardProducts = db.StandardProducts.Include(s => s.Product);
            return View(standardProducts.ToList());
        }

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

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Index");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,AutoOrder")] StandardProduct standardProduct)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,AutoOrder")] StandardProduct standardProduct)
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
