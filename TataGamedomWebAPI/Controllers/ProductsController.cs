using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.DTOs;
using TataGamedomWebAPI.Models.EFModels;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace TataGamedomWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<ProductsIndexDTO>> GetProducts(string? keyword, int page = 1, int pageSize = 9)
        {
          if (_context.Products == null)
          {
              return NotFound();
			}
			//讀出所有資料
			var products = _context.Products.Include(p => p.Game).AsQueryable();

			//商品名稱搜尋（中英文皆可）
			if (!string.IsNullOrEmpty(keyword))
			{
				products = products.Where(p => p.Game.ChiName.Contains(keyword) || p.Game.EngName.Contains(keyword));
			}

			//分頁
			int totalCount = products.Count(); //總共幾筆
											   //int pageSize = 9;  //每頁9筆資料
			int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize); //計算出共幾頁 

			products = products.Skip(pageSize * (page - 1)).Take(pageSize);

			ProductsIndexDTO productsDTO = new ProductsIndexDTO();
			productsDTO.Products = await products.ToListAsync();
			productsDTO.TotalPages = totalPages;

			// 使用JsonSerializerOptions配置循环引用处理
			var serializerOptions = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve,
				MaxDepth = 10 // 或者您可以根据实际需要调整深度的限制
			};

			// 使用Json方法序列化，并指定序列化选项
			var jsonResult = new JsonResult(productsDTO, serializerOptions);
			return jsonResult;
		}

		// GET: api/Products/5
		[HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'AppDbContext.Products'  is null.");
          }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
