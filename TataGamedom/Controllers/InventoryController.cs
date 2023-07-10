using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TataGamedom.Models.Dtos.InventoryItems;
using TataGamedom.Models.Dtos.Orders;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.InventoryItems;
using TataGamedom.Models.ViewModels.Orders;
using System.Web.Script.Serialization;

namespace TataGamedom.Controllers
{
    public class InventoryController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private static readonly IInventoryRepository _repo = new InventoryRepository();
        private readonly InventoryService _service = new InventoryService(_repo);

        public ActionResult Index()
        {
            IEnumerable<InventoryVM> inventory = _service.GetAll();
            return View(inventory);
        }

        public ActionResult Details(int? productId, InventoryCriteria criteria )
        {
			criteria = criteria ?? new InventoryCriteria();
			ViewBag.SalesStatusSelectList = GetSalesStatusSelectList(criteria.SalesStatus);
			ViewBag.ProductId = productId;
			ViewBag.Criteria = criteria;

			IEnumerable<InventoryItemVM> inventorieInfo = _service.GetItemInfo(productId, criteria);
			if (productId == null) return View("");

			return View(inventorieInfo);
        }

		public ActionResult Create()
		{
            PrepareCreateInventoryDataSource(null, null);
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(InventoryItemVM vm)
		{
			if (!ModelState.IsValid) return View(vm);

			PrepareCreateInventoryDataSource(vm.ProductId, vm.StockInSheetIndex);
			Result result = _service.Create(vm.ToDto());
			if (result.IsSuccess)
			{
                TempData["success"] = "新增成功";
                return RedirectToAction("Details", new { productId = vm.ProductId });
			}
			else
			{
				ModelState.AddModelError(string.Empty, result.ErrorMessage);
				return View(vm);
			}

		}


		public ActionResult Edit(string index)
		{
			PrepareCreateInventoryDataSource(null, null);

			if (index == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            InventoryItemVM order = _service.GetByIndex(index).ToVM();
			return View(order);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(InventoryItemVM vm)
		{
			if (!ModelState.IsValid) return View(vm);
			PrepareCreateInventoryDataSource(vm.ProductId, vm.StockInSheetIndex);

			Result result = _service.Update(vm.ToEditDto());
			if (result.IsSuccess)
			{
                TempData["success"] = "編輯成功";
                return RedirectToAction("Details", new { productId = vm.ProductId });
			}
			else
			{
				ModelState.AddModelError(string.Empty, result.ErrorMessage);
				return View(vm);
			}
		}


		private void PrepareCreateInventoryDataSource(int? productId, string StockInSheetIndex)
		{
            List<SelectListItem> productIndexSelectList = new List<SelectListItem>();
			foreach (Product p in db.Products) 
			{
				productIndexSelectList.Add(new SelectListItem { Value = p.Id.ToString(), Text = p.Index }); 
			}

			ViewBag.productIndex = productIndexSelectList;

            List<SelectListItem> StockInSheetIndexSelectList = new List<SelectListItem>();
			foreach (StockInSheet sis in db.StockInSheets) 
			{
				StockInSheetIndexSelectList.Add(new SelectListItem { Value = sis.Id.ToString(), Text = sis.Index }); 
			}
			ViewBag.StockInSheetIndex = StockInSheetIndexSelectList;
		}

        private IEnumerable<SelectListItem> GetSalesStatusSelectList(int? salesStatus)
        {
            Dictionary<int, string> salesStatusName = new Dictionary<int, string> {
                {1,"所有紀錄" },
                {2,"僅顯示當前庫存" },
                {3,"僅顯示過往庫存" },
            };

            foreach (var key in salesStatusName.Keys)
            {
                yield return new SelectListItem { Value = key.ToString(), Text = salesStatusName[key] };
            }

        }
    }
	public class InventoryCriteria
    {
		public int? SalesStatus { get; set; } = 0;

        public string Index { get; set; }
    }
    
}
