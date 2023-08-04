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
using Microsoft.Extensions.Hosting;
using TataGamedomWebAPI.Models.Dtos;
using System.Security.Claims;

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
		public async Task<ActionResult<ProductsIndexDTO>> GetProducts(string? keyword, string? classification, string? sortBy, bool? isAscending, int page = 1, int pageSize = 9)
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
				.Where(p => (p.Game.ChiName.Contains(keyword ?? string.Empty) ||
					 p.Game.EngName.Contains(keyword ?? string.Empty) ||
					 p.GamePlatform.Name.Contains(keyword ?? string.Empty)) &&
					 p.Game.GameClassificationGames.Any(c => c.GameClassification.Name.Contains(classification ?? string.Empty)))
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
		public async Task<ActionResult<SingleProductDTO>> GetSingleProduct(int id, int page = 1, int pageSize = 5)
		{
			if (_context.Products == null)
			{
				return NotFound();
			}
			var currentTime = DateTime.Now;
			SingleProductDTO? product = await _context.Products
				.Where(p => p.Id == id)
				.Include(p => p.CouponsProducts)
				.ThenInclude(c => c.Coupon)
				.Include(p => p.ProductImages)
				.Include(p => p.Game)
				.ThenInclude(g => g.GameClassificationGames)
				.ThenInclude(gc => gc.GameClassification)
				.Include(p => p.GamePlatform)
				.Select(p => new SingleProductDTO
				{
					Id = p.Id,
					Index = p.Index,
					GameId = p.GameId,
					IsVirtual = p.IsVirtual,
					Price = p.Price,
					SpecialPrice = p.CouponsProducts.Any(c => currentTime >= c.Coupon.StartTime && currentTime <= c.Coupon.EndTime)
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
					Coupons = p.CouponsProducts
								.Where(c => currentTime >= c.Coupon.StartTime && currentTime <= c.Coupon.EndTime)
								.Select(c => c.Coupon.Name),
					CouponDescription = p.CouponsProducts
								.Where(c => currentTime >= c.Coupon.StartTime && currentTime <= c.Coupon.EndTime)
								.Select(c => c.Coupon.Description),
					ProductImg = p.ProductImages.Select(p => p.Image)!,
					CommentCount = p.Game.GameComments.Count()
				}).FirstOrDefaultAsync();

			//做評論的分頁
			var (comments, totalPages) = GetGameComments(_context, product.GameId, page, pageSize);
			product.GameComments = comments;
			product.TotalPages = totalPages;

			return product;
		}

		//回傳value tuple
		private (IEnumerable<GameCommentsDTO> Comments, int TotalPages) GetGameComments(AppDbContext context, int? gameId, int page, int pageSize)
		{
			var query = context.GameComments.AsQueryable();
			query = query.Where(p => p.GameId == gameId);
			var comments = query.Select(c => new GameCommentsDTO
			{
				Id = c.Id,
				MemberName = c.Member.Name,
				Content = c.Content,
				Score = c.Score,
				CreatedTime = c.CreatedTime,

			}).ToList();

			int totalCount = comments.Count();
			int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
			List<GameCommentsDTO> commentsList = comments
				.OrderByDescending(c => c.CreatedTime)
				.Skip(pageSize * (page - 1))
				.Take(pageSize)
				.ToList();

			return (commentsList, totalPages);
		}

		// POST: api/Products
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("{id}")]
		public async Task<ActionResult<GameComment>> PostComment(int productId,CommentsCreateDTO commentsCreateDTO)
		{
			if (_context.Products == null)
			{
				return Problem("Entity set 'AppDbContext.Products'  is null.");
			}
			string? userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == userName);
			var product = await _context.Products.FirstOrDefaultAsync(p=>p.Id== productId);
			
			GameComment comments = new GameComment
			{
				GameId = product.GameId ?? 0,
				MemberId = user.Id,
				Content = commentsCreateDTO.Content,
				Score = commentsCreateDTO.Score,
				ActiveFlag = true,
				CreatedTime = DateTime.Now
			};
			_context.GameComments.Add(comments);
			await _context.SaveChangesAsync();

			return Ok("發表評論成功");
		}
	}
}
