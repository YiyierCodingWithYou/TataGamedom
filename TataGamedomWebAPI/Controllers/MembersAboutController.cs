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
	public class MembersAboutController : ControllerBase
	{
		private readonly AppDbContext _context;
		private SimpleHelper _simpleHelper;

		public MembersAboutController(AppDbContext context)
		{
			_context = context;
			_simpleHelper = new SimpleHelper(context);
		}

		[EnableCors("AllowCookie")]
		[HttpGet("{memberAccount}")]
		public async Task<ActionResult<MemberAboutDto>> GetMemberFollow(string memberAccount)
		{
			if (_context.MemberFollows == null)
			{
				return NotFound();
			}

			var loginAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int loginId = _simpleHelper.memberIdByAccount(loginAccount);
			int memberId = _simpleHelper.memberIdByAccount(memberAccount);

			if (memberId == 0)
			{
				return NotFound();
			}
			var query = await _context.Members.FindAsync(memberId);
			var result = new MemberAboutDto()
			{
				Id = query.Id,
				Account = query.Account,
				Name = query.Name,
				IconURL = query.IconImg,
				AboutMe = query.AboutMe,
				IsFollowing = _simpleHelper.MemberIsFollower(loginId, memberId),
				IsFollowingYou = _simpleHelper.MemberIsFollowed(loginId, memberId),
				IsSelf = loginId == memberId,
				FollowerCounting = _context.MemberFollows.Count(m => m.FollowedMemberId == memberId),
				FollowingCounting = _context.MemberFollows.Count(m => m.FollowerMemberId == memberId),
				Followers = _context.MemberFollows.Where(m => m.FollowedMemberId == memberId).Select(x => new FollowerDto()
				{
					Id = x.FollowerMemberId,
					Name = x.FollowerMember.Name,
					IconURL = x.FollowerMember.IconImg,
					IsFollowing = _simpleHelper.MemberIsFollowed(loginId, x.FollowerMemberId ?? 0),
					IsFollowingYou = _simpleHelper.MemberIsFollower(loginId, x.FollowerMemberId ?? 0),
				}).ToList(),
				Followings = _context.MemberFollows.Where(m => m.FollowerMemberId == memberId).Select(x => new FollowerDto()
				{
					Id = x.FollowedMemberId,
					Name = x.FollowedMember.Name,
					IconURL = x.FollowedMember.IconImg,
					IsFollowing = _simpleHelper.MemberIsFollowed(loginId, x.FollowedMemberId ?? 0),
					IsFollowingYou = _simpleHelper.MemberIsFollower(loginId, x.FollowedMemberId ?? 0),
				}).ToList(),
			};

			return result;
		}

		[EnableCors("AllowCookie")]
		[HttpPost("Follow")]
		public async Task<ActionResult> PostMemberFollow(string memberAccount)
		{
			var loginAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int loginId = _simpleHelper.memberIdByAccount(loginAccount);
			int memberId = _simpleHelper.memberIdByAccount(memberAccount);

			if (memberId == 0)
			{
				return NotFound();
			}

			if (loginId == 0)
			{
				return NotFound();
			}

			if (loginId == memberId)
			{
				return NotFound();
			}


			var memberFollow = await _context.MemberFollows.FirstOrDefaultAsync(x => x.FollowerMemberId == loginId && x.FollowedMemberId == memberId);

			if (memberFollow != null)
			{
				try
				{
					_context.MemberFollows.Remove(memberFollow);
					await _context.SaveChangesAsync();
				}
				catch (Exception e)
				{
					return BadRequest(e.Message);
				}
				return Ok("取消追蹤");
			}

			var newMemberFollow = new MemberFollow()
			{
				FollowerMemberId = loginId,
				FollowedMemberId = memberId,
			};

			try
			{
				_context.MemberFollows.Add(newMemberFollow);
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return Ok("追蹤成功");
		}

		[HttpPut]
		[EnableCors("AllowCookie")]
		//change about me
		public async Task<ActionResult> PutMemberAbout(MemberAboutEditDto dto)
		{
			var loginAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int loginId = _simpleHelper.memberIdByAccount(loginAccount);

			if (loginId == 0)
			{
				return NotFound();
			}

			var member = await _context.Members.FindAsync(loginId);

			if (member == null)
			{
				return NotFound();
			}

			member.AboutMe = dto.AboutMe;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return BadRequest("修改失敗" + ex);
			}

			return Ok("修改成功");
		}


		private bool MemberFollowExists(int id)
		{
			return (_context.MemberFollows?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
