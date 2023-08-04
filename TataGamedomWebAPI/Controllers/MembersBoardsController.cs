using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
	public class MembersBoardsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public MembersBoardsController(AppDbContext context)
		{
			_context = context;
		}

		// GET: api/MembersBoards
		[HttpGet]
		public async Task<IEnumerable<MemberFollowBoardListDto>> GetMembersBoardsList()
		{
			if (_context.MembersBoards == null)
			{
				return null;
			}
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用

			return await _context.MembersBoards.Where(b => b.MemberId == memberId)
				.Select(b => new MemberFollowBoardListDto
				{
					Id = b.Id,
					BoardId = b.BoardId,
					BoardName = b.Board.Name,
					IsFavorite = b.IsFavorite,
				})
				.OrderBy(b => b.BoardName)
				.OrderByDescending(b => b.IsFavorite)
				.ToListAsync();
		}

		// GET: api/MembersBoards/5
		[HttpGet("{boardId}")]
		public async Task<IsMemberFollowDto> IsMembersBoard(int boardId)
		{
			if (_context.MembersBoards == null)
			{
				return new IsMemberFollowDto(false, false);
			}
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用

			var isFollow = await _context.MembersBoards.AnyAsync(b => b.BoardId == boardId && b.MemberId == memberId);
			var isFavorite = await _context.MembersBoards.AnyAsync(b => b.BoardId == boardId && b.MemberId == memberId && b.IsFavorite == true);
			return new IsMemberFollowDto(isFollow, isFavorite);
		}

		// PUT: api/MembersBoards/{boardId}/Follow
		[HttpPut("{boardId}/Follow")]
		public async Task<ApiResult> ToggleMembersBoardFollow(int boardId)
		{
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用
			var ExisitingFollow = _context.MembersBoards
				.FirstOrDefault(b => b.BoardId == boardId && b.MemberId == memberId);

			if (ExisitingFollow == null)
			{
				var newFollow = new MembersBoard
				{
					Id = 0,
					MemberId = memberId,
					BoardId = boardId,
					IsFavorite = false
				};

				try
				{
					_context.MembersBoards.Add(newFollow);
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					return ApiResult.Fail("追蹤失敗");
				}
				return ApiResult.Success("追蹤成功");
			}
			else
			{
				try
				{
					_context.MembersBoards.Remove(ExisitingFollow);
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					return ApiResult.Fail("移除追蹤失敗");
				}
				return ApiResult.Success("移除追蹤成功");
			}
		}

		// PUT: api/MembersBoards/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{boardId}/Favorite")]
		public async Task<ApiResult> ToggleMembersBoardFavorite(int boardId)
		{
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用
			var ExisitingFollow= _context.MembersBoards
				.FirstOrDefault(b => b.BoardId == boardId && b.MemberId == memberId);
			var ExisitingFavo = _context.MembersBoards
				.Where(b => b.IsFavorite == true)
				.FirstOrDefault(b => b.BoardId == boardId && b.MemberId == memberId);

			if (ExisitingFollow == null) {
				var newFollowFavo = new MembersBoard
				{
					Id = 0,
					MemberId = memberId,
					BoardId = boardId,
					IsFavorite = true
				};

				try
				{
					_context.MembersBoards.Add(newFollowFavo);
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					return ApiResult.Fail("加入最愛失敗");
				}
				return ApiResult.Success("加入最愛成功");
			}

			if (ExisitingFollow != null && ExisitingFavo == null)
			{
				try
				{
					ExisitingFollow.IsFavorite = true;
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					return ApiResult.Fail("加入最愛失敗");
				}
				return ApiResult.Success("加入最愛成功");
			}
			else
			{
				try
				{
					ExisitingFollow.IsFavorite = false;
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					return ApiResult.Fail("移除最愛失敗");
				}
				return ApiResult.Success("移除最愛成功");
			}
		}

		// POST: api/MembersBoards
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPost]
		//public async Task<ActionResult<MembersBoard>> PostMembersBoard(MembersBoard membersBoard)
		//{
		//	if (_context.MembersBoards == null)
		//	{
		//		return Problem("Entity set 'AppDbContext.MembersBoards'  is null.");
		//	}
		//	_context.MembersBoards.Add(membersBoard);
		//	await _context.SaveChangesAsync();

		//	return CreatedAtAction("GetMembersBoard", new { id = membersBoard.Id }, membersBoard);
		//}


		private bool MembersBoardExists(int id)
		{
			return (_context.MembersBoards?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
