using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.Coupons;
using Dapper;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Office2016.Drawing;

namespace TataGamedom.Controllers
{
	[Route("Coupons/{couponId}")]
	public class CouponsController : Controller
	{
		private AppDbContext db = new AppDbContext();
		private string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
		[Authorize]
		// GET: Coupons
		public ActionResult Index()
		{
			IEnumerable<CouponIndexVM> coupons = GetCoupons();
			return View(coupons);
		}

		private IEnumerable<CouponIndexVM> GetCoupons()
		{
			ICouponRepository repo = new CouponDapperRepository();
			CouponService service = new CouponService(repo);
			return service.Get();
		}
		public ActionResult Create()
		{
			return View(GetCreateInfo());
		}

		private CouponCreateVM GetCreateInfo()
		{
			List<DiscountTypeCode> discountTypes = db.DiscountTypeCodes.ToList();
			CouponCreateVM vm = new CouponCreateVM();
			vm.DiscountTypeCode = discountTypes;
			vm.StartTime = DateTime.Now;
			vm.EndTime = DateTime.Now;
			return vm;
		}

		[HttpPost]
		public ActionResult Create(CouponCreateVM vm)
		{
			ICouponRepository repo = new CouponDapperRepository();
			CouponService service = new CouponService(repo);
			if (!ModelState.IsValid)
			{
				return View(GetCreateInfo());
			}

			var currentUserAccount = User.Identity.Name;
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
			vm.CreatedBackendMemberId = memberInDb.Id;
			var createResult = service.Create(vm);
			if (createResult.IsFail)
			{
				ModelState.AddModelError("", createResult.ErrorMessage);
				return View(createResult);
			}
			return RedirectToAction("Index");
		}
		public ActionResult Edit(int id)
		{
			List<DiscountTypeCode> discountTypes = db.DiscountTypeCodes.ToList();

			var couponInDb = db.Coupons.FirstOrDefault(m => m.Id == id);
			var modifiedBackendMember = db.BackendMembers.FirstOrDefault(m => m.Id == couponInDb.ModifiedBackendMemberId);

			var coupon = new CouponEditVM
			{
				Id = couponInDb.Id,
				Name = couponInDb.Name,
				Discount = couponInDb.Discount,
				DiscountTypeCode = discountTypes,
				DiscountTypeId = couponInDb.DiscountTypeId,
				Description = couponInDb.Description,
				ModifiedBackendMemberName = modifiedBackendMember != null ? modifiedBackendMember.Name : null,
				Threshold = couponInDb.Threshold,
				ModifiedTime = couponInDb.ModifiedTime,
				StartTime = couponInDb.StartTime,
				EndTime = couponInDb.EndTime,
				ActiveFlag = couponInDb.ActiveFlag
			};

			return View(coupon);
		}

		[HttpPost]
		public ActionResult Edit(CouponEditVM vm)
		{
			if (ModelState.IsValid)
			{
				var currentUserAccount = User.Identity.Name;
				var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
				// 取得要編輯的優惠券資料
				var couponInDb = db.Coupons.FirstOrDefault(m => m.Id == vm.Id);
				var status = false;
				if (couponInDb != null)
				{
					// 更新優惠券的屬性值
					couponInDb.Name = vm.Name;
					couponInDb.Discount = vm.Discount;
					couponInDb.DiscountTypeId = vm.DiscountTypeId;
					couponInDb.Description = vm.Description;
					couponInDb.ModifiedBackendMemberId = memberInDb.Id;
					couponInDb.Threshold = vm.Threshold;
					couponInDb.ModifiedTime = DateTime.Now;

					var selectedStartDate = vm.StartTime.Date;
					var selectedEndDate = vm.EndTime.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
					if (DateTime.Now >= selectedStartDate && DateTime.Now <= selectedEndDate)
					{
						status = true;
					}
					couponInDb.StartTime = selectedStartDate;
					couponInDb.EndTime = selectedEndDate;
					couponInDb.ActiveFlag = status;

					// 儲存變更
					db.SaveChanges();

					return RedirectToAction("Index");
				}
				else
				{
					// 沒有找到對應的優惠券，顯示錯誤訊息
					ModelState.AddModelError("", "找不到該優惠券的資料");
				}
			}
			// 若資料驗證失敗，返回編輯頁面並顯示錯誤訊息
			return View(vm);
		}
		public ActionResult EditCouponProducts(int id)
		{
			var coupon = db.Coupons.FirstOrDefault(c => c.Id == id);
			if (coupon == null)
			{
				return HttpNotFound();
			}

			var couponProducts = db.CouponsProducts
				.Where(cp => cp.CouponId == coupon.Id)
				.Select(cp => cp.ProductId)
				.ToList();

			var availableProducts = db.Products
				.Include("Game")
				.OrderBy(p => p.Game.ChiName) // 按照遊戲名稱排序
				.ToList();

			var viewModel = new EditCouponProductsVM
			{
				Id = coupon.Id,
				CouponName = coupon.Name,
				Description = coupon.Description,
				EndTime = coupon.EndTime,
				SelectedProductIds = couponProducts,
				AvailableProducts = availableProducts
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult EditCouponProducts(EditCouponProductsVM model)
		{
			var couponId = model.Id;

			// 取得已存在的產品關聯資料
			var existingCouponProducts = db.CouponsProducts
				.Where(cp => cp.CouponId == couponId)
				.ToList();

			// 新增選取的產品關聯資料
			if (model.SelectedProductIds != null)
			{
				foreach (var productId in model.SelectedProductIds)
				{
					bool isExisting = existingCouponProducts.Any(cp => cp.ProductId == productId);

					if (!isExisting)
					{
						var couponProduct = new CouponsProduct
						{
							CouponId = couponId,
							ProductId = productId
						};
						db.CouponsProducts.Add(couponProduct);
					}
				}
			}

			// 刪除取消選取的產品關聯資料並將取消選取的選項加回商品列表中
			foreach (var couponProduct in existingCouponProducts)
			{
				bool isSelected = model.SelectedProductIds.Contains(couponProduct.ProductId);

				if (!isSelected)
				{
					db.CouponsProducts.Remove(couponProduct);

					// 將取消選取的選項加回商品列表中
					var product = db.Products.FirstOrDefault(p => p.Id == couponProduct.ProductId);
					if (product != null)
					{
						model.AvailableProducts.Add(product);
					}
				}
			}

			// 儲存變更
			db.SaveChanges();

			// 返回到相應的視圖或進行其他操作

			return RedirectToAction("Index");
		}
		
		
		[Authorize]
		public ActionResult CouponsProductsIndex()
		{
			using (var conn = new SqlConnection(_connStr))
			{
				string sql = @"SELECT
    P.[Index],
    G.ChiName AS Name,
    GPC.Name AS Platform,
    C.Name AS CouponName,
    C.Threshold,
    C.Description,
    P.Price,
    CASE
        WHEN C.DiscountTypeId = 1 AND P.Price > C.Threshold THEN P.Price * (C.Discount / 100)
        WHEN C.DiscountTypeId = 2 AND P.Price > C.Threshold THEN P.Price - C.Discount
        ELSE P.Price
    END AS SpecialPrice,
    CASE
        WHEN (
            CASE
                WHEN C.DiscountTypeId = 1 THEN P.Price * (C.Discount / 100)
                WHEN C.DiscountTypeId = 2 THEN P.Price - C.Discount
                ELSE P.Price
            END
        ) < 0 THEN 0
        ELSE (
            CASE
                WHEN C.DiscountTypeId = 1 THEN P.Price * (C.Discount / 100)
                WHEN C.DiscountTypeId = 2 THEN P.Price - C.Discount
                ELSE P.Price
            END
        )
    END AS IfReach
FROM
    CouponsProducts AS CP
    JOIN Coupons AS C ON C.Id = CP.CouponId
    JOIN Products AS P ON P.Id = CP.ProductId
    JOIN Games AS G ON G.Id = P.GameId
    JOIN GamePlatformsCodes AS GPC ON GPC.Id = P.GamePlatformId
WHERE
    C.ActiveFlag = 1";

				var list = conn.Query<CouponsProductsIndexVM>(sql).ToList();
				return View(list);
			}
		}
	}
}