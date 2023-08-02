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
using Dapper;
using Microsoft.Data.SqlClient;
using TataGamedomWebAPI.Models.DTOs.Shop;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Globalization;

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
		public async Task<ActionResult<ProductsIndexDTO>> GetProducts(string? keyword,string? classification, string? sortBy, bool? isAscending, int page = 1, int pageSize = 9)
		{
			if (_context.Products == null)
			{
				return NotFound();
			}
			var currentTime = DateTime.Now;
			IQueryable<ProductsDTO> products = _context.Products
				.Include(p => p.CouponsProducts)
				.ThenInclude(c => c.Coupon)
				.Include(p => p.Game)
				.ThenInclude(g => g.GameClassificationGames)
				.ThenInclude(gc => gc.GameClassification)
				.Include(p => p.GamePlatform)
				.Where(p => p.Game.ChiName.Contains(keyword ?? string.Empty) ||
							p.Game.EngName.Contains(keyword ?? string.Empty) ||
							p.GamePlatform.Name.Contains(keyword ?? string.Empty)) //||
				//p.Game.GameClassificationGames.Any(gc => gc.GameClassification.Name.Contains(classification?? string.Empty)))
				.Select(p => new ProductsDTO
				{
					Id = p.Id,
					Index = p.Index,
					IsVirtual = p.IsVirtual,
					Price = p.Price,
					SpecialPrice = (p.CouponsProducts.Any(c => currentTime >= c.Coupon.StartTime && currentTime <= c.Coupon.EndTime))
									? (int)Math.Round(p.CouponsProducts
										.Select(c => c.Coupon.DiscountTypeId == 1
											? p.Price * (c.Coupon.Discount / 100.0)
											: (c.Coupon.DiscountTypeId == 2
												? p.Price - c.Coupon.Discount
												: p.Price))
										.FirstOrDefault(), 1)
									: p.Price,
					GamePlatformName = p.GamePlatform.Name,
					SaleDate = p.SaleDate,
					Score = Math.Round(p.Game.GameComments.Select(c => (double?)c.Score).Average() ?? 0.0, 1),
					ChiName = p.Game.ChiName,
					EngName = p.Game.EngName,
					IsRestrict = p.Game.IsRestrict,
					GameCoverImg = p.Game.GameCoverImg,
					Classification = p.Game.GameClassificationGames.Select(gc => gc.GameClassification.Name)
				});

			switch (sortBy)
			{
				case "Price":
					products = (isAscending == false)
						? products.OrderByDescending(p => p.SpecialPrice)
						: products.OrderBy(p => p.SpecialPrice);
					break;
				case "SaleDate":
					products = (isAscending == false)
						? products.OrderByDescending(p => p.SaleDate)
						: products.OrderBy(p => p.SaleDate);
					break;
				default:
					products = products.OrderBy(p => p.Id);
					break;
			}

			int totalCount = await products.CountAsync();
			int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
			List<ProductsDTO> productsList = await products
				.Skip(pageSize * (page - 1))
				.Take(pageSize)
				.ToListAsync();

			ProductsIndexDTO productsDTO = new ProductsIndexDTO
			{
				Products = productsList,
				TotalPages = totalPages
			};
			return productsDTO;
		}

		// GET: api/Products/5
		[HttpGet("{id}")]
		public async Task<ActionResult<SingleProductDTO>> GetProduct(int id)
		{
			if (_context.Products == null)
			{
				return NotFound();
			}
			var currentTime = DateTime.Now;
			SingleProductDTO? product =await _context.Products
				.Where(p => p.Id == id)
				.Include(p => p.CouponsProducts)
				.ThenInclude(c => c.Coupon)
				.Include(p=>p.ProductImages)
				.Include(p => p.Game)
				.ThenInclude(g => g.GameClassificationGames)
				.ThenInclude(gc => gc.GameClassification)
				.Include(p => p.GamePlatform)
				.Select(p => new SingleProductDTO
				{
					Id = p.Id,
					Index = p.Index,
					IsVirtual = p.IsVirtual,
					Price = p.Price,
					SpecialPrice = (p.CouponsProducts.Any(c => currentTime >= c.Coupon.StartTime && currentTime <= c.Coupon.EndTime))
									? (int)Math.Round(p.CouponsProducts
										.Select(c => c.Coupon.DiscountTypeId == 1
											? p.Price * (c.Coupon.Discount / 100.0)
											: (c.Coupon.DiscountTypeId == 2
												? p.Price - c.Coupon.Discount
												: p.Price))
										.FirstOrDefault(), 1)
									: p.Price,
					GamePlatformName = p.GamePlatform.Name,
					SaleDate = p.SaleDate,
					Score = Math.Round(p.Game.GameComments.Select(c => (double?)c.Score).Average() ?? 0.0, 1),
					ChiName = p.Game.ChiName,
					EngName = p.Game.EngName,
					Description = p.Game.Description,
					SystemRequire = p.SystemRequire,
					IsRestrict = p.Game.IsRestrict,
					GameCoverImg = p.Game.GameCoverImg,
					Classification = p.Game.GameClassificationGames.Select(gc => gc.GameClassification.Name),
					Coupons = p.CouponsProducts.Select(c=>c.Coupon.Name),
					CouponDescription = p.CouponsProducts.Select (c=>c.Coupon.Description),
					ProductImg = p.ProductImages.Select(p=>p.Image)!,
				}).FirstOrDefaultAsync();

			if (product == null)
			{
				return NotFound();
			}
			return product;
		}

		// PUT: api/Products/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutSingleProduct(int id, Product product)
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
