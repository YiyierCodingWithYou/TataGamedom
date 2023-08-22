using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.DTOs.Board;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BoardsController : ControllerBase
	{
		private readonly AppDbContext _context;
		private SimpleHelper _simpleHelper;

		public BoardsController(AppDbContext context)
		{
			_context = context;
			_simpleHelper = new SimpleHelper(_context);
		}

		// GET: api/Boards
		[HttpGet]
		[EnableCors("AllowCookie")]
		public async Task<ActionResult<IEnumerable<BoardReadDto>>> GetBoards(string? memberAccount)
		{
			string loggedInAccount = HttpContext.User.FindFirstValue("MembersAccount");
			int loggedInMemberId = _simpleHelper.memberIdByAccount(loggedInAccount);
			DateTime currentTime = DateTime.Now;
			DateTime twoDaysAgo = currentTime.AddHours(-48);

			if (_context.Boards == null)
			{
				return NotFound();
			}

			IQueryable<Board> query;

			if (memberAccount != null)
			{
				query = _context.MembersBoards.Where(m => m.Member.Account == memberAccount).Select(b => b.Board);
			}
			else
			{
				query = _context.Boards;
			}

			var dto = await query.Select(b => new BoardReadDto
			{
				Id = b.Id,
				Name = b.Name,
				BoardAbout = b.BoardAbout,
				BoardHeaderCoverImgUrl = $"https://localhost:7081/Files/Uploads/{b.BoardHeaderCoverImg}",
				BoardUrl = $"https://localhost:3000/GameLounge/Board/{b.Id}",
				GameId = b.GameId,
				GameName = b.Game.ChiName,
				PostCurrentCount = b.Posts.Count(p => p.Datetime >= twoDaysAgo && p.Datetime <= currentTime && p.ActiveFlag),
				PostTotalCount = b.Posts.Count(p => p.ActiveFlag),
				MemberFollowCount = b.MembersBoards.Count(),
				IsFollowed = b.MembersBoards.Any(m => m.MemberId == loggedInMemberId),
				IsFavorite = b.MembersBoards.Any(m => m.MemberId == loggedInMemberId && m.IsFavorite),
				IsMod = b.BoardsModerators.Any(m => m.ModeratorMember.Account == loggedInAccount),
				Mods = b.BoardsModerators.Select(m => new ModReadDto
				{
					Id = m.ModeratorMemberId,
					Account = m.ModeratorMember.Account,
					Name = m.ModeratorMember.Name,
				}),
				ProductLinks = b.Game.Products.Select(p => new ProducLinkDto
				{
					Id = p.Id,
					PlatformName = p.GamePlatform.Name,
					Url = $"https://localhost:3000/eCommerce/Product/{p.Id}",
				})
			})
				.OrderByDescending(b => b.PostCurrentCount)
				.OrderByDescending(b => b.IsFavorite)
				.ToListAsync();

			return dto;
		}

		// GET: api/Boards/5
		[HttpGet("{id}")]
		[EnableCors("AllowCookie")]
		public async Task<ActionResult<BoardReadDto>> GetBoard(int id)
		{
			string loggedInAccount = HttpContext.User.FindFirstValue("MembersAccount");
			int loggedInMemberId = _simpleHelper.memberIdByAccount(loggedInAccount);
			DateTime currentTime = DateTime.Now;
			DateTime twoDaysAgo = currentTime.AddHours(-48);

			if (_context.Boards == null)
			{
				return NotFound();
			}

			var dto = await _context.Boards
			.Select(b => new BoardReadDto
			{
				Id = b.Id,
				Name = b.Name,
				BoardAbout = b.BoardAbout,
				BoardHeaderCoverImgUrl = $"https://localhost:7081/Files/Uploads/{b.BoardHeaderCoverImg}",
				BoardUrl = $"https://localhost:3000/GameLounge/Board/{b.Id}",
				GameId = b.GameId,
				GameName = b.Game.ChiName,
				PostCurrentCount = b.Posts.Count(p => p.Datetime >= twoDaysAgo && p.Datetime <= currentTime && p.ActiveFlag),
				PostTotalCount = b.Posts.Count(p => p.ActiveFlag),
				MemberFollowCount = b.MembersBoards.Count(),
				IsFollowed = b.MembersBoards.Any(m => m.MemberId == loggedInMemberId),
				IsFavorite = b.MembersBoards.Any(m => m.MemberId == loggedInMemberId && m.IsFavorite),
				IsMod = b.BoardsModerators.Any(m => m.ModeratorMember.Account == loggedInAccount),
				Mods = b.BoardsModerators.Select(m => new ModReadDto
				{
					Id = m.ModeratorMemberId,
					Account = m.ModeratorMember.Account,
					Name = m.ModeratorMember.Name,
				}),
				ProductLinks = b.Game.Products.Select(p => new ProducLinkDto
				{
					Id = p.Id,
					PlatformName = p.GamePlatform.Name,
					Url = $"https://localhost:3000/eCommerce/Product/{p.Id}",
				})
			})
			.FirstOrDefaultAsync(b => b.Id == id);

			if(dto == null)
			{
				return NotFound();
			}

			return dto;
		}

	}
}
