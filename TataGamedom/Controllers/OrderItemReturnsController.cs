using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.Dtos.OrderItemReturns;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.OrderItemReturns;

namespace TataGamedom.Controllers
{
    public class OrderItemReturnsController : Controller
    {
		private readonly AppDbContext db = new AppDbContext();
		private static readonly IOrderItemReturnRepository _repo = new OrderItemReturnRepository();
		private readonly OrderItemReturnService _service = new OrderItemReturnService(_repo);

		public ActionResult Index() => View(_service.Search().Select(orderItemReturn => orderItemReturn.ToVM()));

        public ActionResult Details(string orderIndex) => View(_service.GetByIndex(orderIndex).Select(orderItemReturn => orderItemReturn.ToVM()));


        public ActionResult Create()
        {
            PrepareCreateDataSource(null);

			return View();
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(OrderItemReturnVM vm)
        {
			if (!ModelState.IsValid) return View(vm);

			PrepareCreateDataSource(vm.OrderItemId);

			Result result = _service.Create(vm.ToDto());
			if (result.IsSuccess)
			{
				return RedirectToAction("Index");
			}
			else
			{
				ModelState.AddModelError(string.Empty, result.ErrorMessage);
				return View(vm);
			}
		}

        public ActionResult Edit(int? id)
        {
            PrepareCreateDataSource(null);

            if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var orderItemReturn = _service.GetById(id).ToVM();
			return View(orderItemReturn);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(OrderItemReturnVM vm)
        {
			if (!ModelState.IsValid) return View(vm);

			PrepareCreateDataSource(vm.OrderItemId);

			Result result = _service.Update(vm.ToDto());
			if (result.IsSuccess)
			{
				return RedirectToAction("Index");
			}
			else
			{
				ModelState.AddModelError(string.Empty, result.ErrorMessage);
				return View(vm);
			}
		}

        public ActionResult Delete(int? id)
        {
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var orderItemReturn = _service.GetById(id).ToVM();
			return View(orderItemReturn);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int? id)
        {
			_service.Delete(id);
            return RedirectToAction("Index");
     
        }

		private void PrepareCreateDataSource(int? orderItemId)
		{
			var orderItemIdSelectList = new List<SelectListItem>();
			foreach (var item in db.OrderItems.Where(item => !db.OrderItemReturns.Any(itemReturn => itemReturn.OrderItemId == item.Id)))
			{
				orderItemIdSelectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Index });
			}

			ViewBag.OrderItemId = orderItemIdSelectList;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing) db.Dispose();
			base.Dispose(disposing);
		}

	}
}
