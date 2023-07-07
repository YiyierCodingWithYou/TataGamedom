using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;

namespace TataGamedom.Controllers.Api
{
	public class CouponsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();

		//// GET: api/CouponsApi
		//public IQueryable<Coupon> GetCoupons()
		//{
		//    return db.Coupons;
		//}

		//// GET: api/CouponsApi/5
		//[ResponseType(typeof(Coupon))]
		//public IHttpActionResult GetCoupon(int id)
		//{
		//    Coupon coupon = db.Coupons.Find(id);
		//    if (coupon == null)
		//    {
		//        return NotFound();
		//    }

		//    return Ok(coupon);
		//}

		//// PUT: api/CouponsApi/5
		//[ResponseType(typeof(void))]
		//public IHttpActionResult PutCoupon(int id, Coupon coupon)
		//{
		//    if (!ModelState.IsValid)
		//    {
		//        return BadRequest(ModelState);
		//    }

		//    if (id != coupon.Id)
		//    {
		//        return BadRequest();
		//    }

		//    db.Entry(coupon).State = EntityState.Modified;

		//    try
		//    {
		//        db.SaveChanges();
		//    }
		//    catch (DbUpdateConcurrencyException)
		//    {
		//        if (!CouponExists(id))
		//        {
		//            return NotFound();
		//        }
		//        else
		//        {
		//            throw;
		//        }
		//    }

		//    return StatusCode(HttpStatusCode.NoContent);
		//}

		//// POST: api/CouponsApi
		//[ResponseType(typeof(Coupon))]
		//public IHttpActionResult PostCoupon(Coupon coupon)
		//{
		//    if (!ModelState.IsValid)
		//    {
		//        return BadRequest(ModelState);
		//    }

		//    db.Coupons.Add(coupon);
		//    db.SaveChanges();

		//    return CreatedAtRoute("DefaultApi", new { id = coupon.Id }, coupon);
		//}

		// DELETE: api/CouponsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult DeleteCoupon(int id)
		{
			Coupon coupon;

			coupon = db.Coupons.FirstOrDefault(c => c.Id == id);

			if (coupon == null)
			{
				return ApiResult.Fail("該優惠券不存在！");
			}
			//活動已結束
			if (coupon.EndTime < DateTime.Now)
			{
				return ApiResult.Fail("無法刪除已結束的優惠券");
			}
			//活動未開始 or 活動進行中
			if ((coupon.StartTime > DateTime.Now) || (coupon.StartTime <= DateTime.Now && coupon.EndTime > DateTime.Now))
			{
				var hasRelatedData = db.CouponsProducts.Any(cp => cp.Id == id);
				if (hasRelatedData) //有適用商品
				{
					return ApiResult.Fail("無法刪除有適用商品之優惠券");
				}
				
			}
			//無適用商品
			try
			{
				db.Coupons.Remove(coupon);
				db.SaveChanges();
				return ApiResult.Success("優惠券已成功刪除。");
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("無法刪除該優惠券，因為它正在被使用或與其他相關資料有關聯，請聯繫工程師 :) ");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool CouponExists(int id)
		{
			return db.Coupons.Count(e => e.Id == id) > 0;
		}
	}
}