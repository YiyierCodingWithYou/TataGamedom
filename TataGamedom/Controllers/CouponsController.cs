using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.Coupons;

namespace TataGamedom.Controllers
{
	public class CouponsController : Controller
	{
		private AppDbContext db = new AppDbContext();
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
				ModelState.AddModelError("", "新增優惠券失敗");
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
	}
}