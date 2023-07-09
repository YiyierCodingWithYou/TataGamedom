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
    public class ProductsApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

		//// GET: api/ProductsApi
		//public IQueryable<Product> GetProducts()
		//{
		//    return db.Products;
		//}

		//// GET: api/ProductsApi/5
		//[ResponseType(typeof(Product))]
		//public IHttpActionResult GetProduct(int id)
		//{
		//    Product product = db.Products.Find(id);
		//    if (product == null)
		//    {
		//        return NotFound();
		//    }

		//    return Ok(product);
		//}

		//// PUT: api/ProductsApi/5
		//[ResponseType(typeof(void))]
		//public IHttpActionResult PutProduct(int id, Product product)
		//{
		//    if (!ModelState.IsValid)
		//    {
		//        return BadRequest(ModelState);
		//    }

		//    if (id != product.Id)
		//    {
		//        return BadRequest();
		//    }

		//    db.Entry(product).State = EntityState.Modified;

		//    try
		//    {
		//        db.SaveChanges();
		//    }
		//    catch (DbUpdateConcurrencyException)
		//    {
		//        if (!ProductExists(id))
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

		//// POST: api/ProductsApi
		//[ResponseType(typeof(Product))]
		//public IHttpActionResult PostProduct(Product product)
		//{
		//    if (!ModelState.IsValid)
		//    {
		//        return BadRequest(ModelState);
		//    }

		//    db.Products.Add(product);
		//    db.SaveChanges();

		//    return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
		//}

		// DELETE: api/ProductsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult DeleteProduct(int id)
        {
			Product product = db.Products.Find(id);
			if (product == null)
			{
				return ApiResult.Fail("該商品不存在！");
			}

			try
			{
				// 查詢並移除商品圖片
				List<ProductImage> images = db.ProductImages.Where(img => img.ProductId == id).ToList();
				db.ProductImages.RemoveRange(images);

				// 移除商品
				db.Products.Remove(product);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("無法刪除該商品，因為它與其他資料有關聯，請聯繫工程師 :) ");
			}

			return ApiResult.Success("商品刪除成功！");
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}