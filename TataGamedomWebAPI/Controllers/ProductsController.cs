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
using Microsoft.AspNetCore.Cors;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Models.DTOs.PostComment;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TataGamedomWebAPI.Controllers
{
	[EnableCors("AllowAny")]
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
		public async Task<ActionResult<ProductsIndexDTO>> GetProducts(string? keyword, string? platform, string? classification, string? sortBy, bool? isAscending, int page = 1, int pageSize = 9)
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
				.Where(p =>
		(string.IsNullOrEmpty(keyword) || p.Game.ChiName.Contains(keyword) || p.Game.EngName.Contains(keyword)) &&
		(string.IsNullOrEmpty(platform) || p.GamePlatform.Name.Contains(platform)) &&
		(string.IsNullOrEmpty(classification) || p.Game.GameClassificationGames.Any(c => c.GameClassification.Name.Contains(classification))))
				.Select(p => new ProductsDTO
				{
					Id = p.Id,
					Index = p.Index,
					IsVirtual = p.IsVirtual,
					Price = p.Price,
					SpecialPrice = p.CouponsProducts
							.Any(cp => currentTime >= cp.Coupon.StartTime && currentTime <= cp.Coupon.EndTime && cp.ProductId == p.Id)
							? (int)Math.Round(p.CouponsProducts
										.Where(cp => currentTime >= cp.Coupon.StartTime && currentTime <= cp.Coupon.EndTime && cp.ProductId == p.Id)
										.Select(cp => cp.Coupon.DiscountTypeId == 1
										? p.Price * (cp.Coupon.Discount / 100.0)
										: (cp.Coupon.DiscountTypeId == 2
										? p.Price - cp.Coupon.Discount
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
					SpecialPrice = p.CouponsProducts
							.Any(cp => currentTime >= cp.Coupon.StartTime && currentTime <= cp.Coupon.EndTime && cp.ProductId == p.Id)
							? (int)Math.Round(p.CouponsProducts
										.Where(cp => currentTime >= cp.Coupon.StartTime && currentTime <= cp.Coupon.EndTime && cp.ProductId == p.Id)
										.Select(cp => cp.Coupon.DiscountTypeId == 1
										? p.Price * (cp.Coupon.Discount / 100.0)
										: (cp.Coupon.DiscountTypeId == 2
										? p.Price - cp.Coupon.Discount
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
					CommentCount = p.Game.GameComments.Where(c => c.ActiveFlag == true).Count(),
					BoardId = p.Game.Boards.Where(b => b.GameId == p.GameId).Select(b => b.Id).FirstOrDefault(),
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
			query = query.Where(p => p.GameId == gameId && p.ActiveFlag == true).OrderByDescending(p => p.CreatedTime);
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
				.Skip(pageSize * (page - 1))
				.Take(pageSize)
				.ToList();

			return (commentsList, totalPages);
		}

		// POST: api/Products
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[EnableCors("AllowCookie")]
		[HttpPost]
		public async Task<ApiResult> PostComment(int productId, CommentsCreateDTO commentsCreateDTO)
		{
			if (_context.Products == null)
			{
				return ApiResult.Fail("無此商品");
			}
			string? userName = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == userName);
			var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
			if (user == null)
			{
				return ApiResult.Fail("請先登入會員");
			}
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

			return ApiResult.Success("發表評論成功");
		}

		[HttpGet("Classification")]
		public async Task<IEnumerable<GameClassificationsCode>> GetClassification()
		{
			if (_context.GameClassificationsCodes == null)
			{
				return null;
			}
			var classification = _context.GameClassificationsCodes.AsQueryable();
			return classification;
		}

		//[EnableCors("AllowCookie")]
		//[HttpGet("TrackProducts")]
		//public async Task<ActionResult<TrackProductDTO>> GetTrackProducts()
		//{
		//	var account = HttpContext.User.FindFirstValue(ClaimTypes.Name);
		//	var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);
		//	var currentTime = DateTime.Now;

		//	var trackList = await _context.TrackProducts
		//		.Where(p => p.MemberId == user.Id)
		//		.Select(p => new TrackProductDTO
		//		{
		//			TrackItems = new List<SingleProductDTO>
		//			{
		//		new SingleProductDTO
		//		{
		//			Id = p.ProductId,
		//			ChiName = p.Product.Game.ChiName,
		//			GameCoverImg = p.Product.Game.GameCoverImg,
		//			GamePlatformName = p.Product.GamePlatform.Name,
		//			Price = p.Product.Price,
		//			SpecialPrice = p.Product.CouponsProducts
		//				.Any(cp => currentTime >= cp.Coupon.StartTime && currentTime <= cp.Coupon.EndTime && cp.ProductId == p.ProductId)
		//				? (int)Math.Round(p.Product.CouponsProducts
		//					.Where(cp => currentTime >= cp.Coupon.StartTime && currentTime <= cp.Coupon.EndTime && cp.ProductId == p.ProductId)
		//					.Select(cp => cp.Coupon.DiscountTypeId == 1
		//						? p.Product.Price * (cp.Coupon.Discount / 100.0)
		//						: (cp.Coupon.DiscountTypeId == 2
		//							? p.Product.Price - cp.Coupon.Discount
		//							: p.Product.Price))
		//					.FirstOrDefault(), 1)
		//				: p.Product.Price,
		//		}
		//			}
		//		})
		//		.ToListAsync();

		//	var trackProductDTO = new TrackProductDTO
		//	{
		//		TrackItems = trackList.SelectMany(dto => dto.TrackItems)
		//	};

		//	return trackProductDTO;
		//}

		//[EnableCors("AllowAny")]
		//[HttpPost("TrackProducts")]
		//public async Task<ApiResult> AddTrackProduct(int productId)
		//{
		//	var account = HttpContext.User.FindFirstValue(ClaimTypes.Name);
		//	var user = await _context.Members.FirstOrDefaultAsync(m => m.Account == account);
		//	if (user == null)
		//	{
		//		return ApiResult.Fail("請先登入會員");
		//	}

		//	var thisProduct = await _context.TrackProducts.FirstOrDefaultAsync(p => p.ProductId == productId && p.MemberId == user.Id);
		//	if (product != null)
		//	{
		//		_context.TrackProducts.Remove(thisProduct);
		//		await _context.SaveChangesAsync();
		//		return ApiResult.Success("已取消追蹤該商品")
		//	}
		//	TrackProducts product = new TrackProducts
		//	{
		//		ProductId = productId,
		//		MemberId = user.Id
		//	};
		//	_context.TrackProducts.Add(product);
		//	await _context.SaveChangesAsync();

		//	return ApiResult.Success("商品已成功加入追蹤清單");
		//}

	}
}
