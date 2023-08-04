using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.DTOs.PostComment;
using TataGamedomWebAPI.Models.EFModels;


namespace TataGamedomWebAPI.Controllers
{
    [EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class PostCommentsController : ControllerBase
	{
		private readonly AppDbContext _context;
		private SimpleHelper _simpleHelper;

		public PostCommentsController(AppDbContext context)
		{
			_context = context;
			_simpleHelper = new SimpleHelper(context);
		}


		[HttpPut("{commentId}/Vote/{voteType}")]
		public async Task<ApiResult> VotePost(int commentId, string voteType)
		{
			PostComment existingPost = _context.PostComments.Find(commentId);
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用
			var IsVoted = _simpleHelper.IsCommentVoted(commentId, memberId);

			if (existingPost == null)
			{
				return ApiResult.Fail("不存在該文章");
			}

			if (IsVoted.IsVoted)
			{
				PostCommentUpDownVote vote = _context.PostCommentUpDownVotes.Find(IsVoted.voteId);
				try
				{
					_context.PostCommentUpDownVotes.Remove(vote);
					await _context.SaveChangesAsync();
					return ApiResult.Success("完成取消投票");
				}
				catch (Exception ex)
				{
					return ApiResult.Fail("無法取消投票" + ex.Message);
				}
			}

			if (!Enum.TryParse<Vote>(voteType, out var voteValue))
			{
				return ApiResult.Fail("不支援的投票類型");
			}

			PostCommentUpDownVote newVote = new PostCommentUpDownVote
			{
				Id = 0,
				MemberId = memberId,
				PostCommentId = commentId,
				Date = DateTime.Now,
				Type = (voteValue == Vote.Up)
			};

			try
			{
				_context.PostCommentUpDownVotes.Add(newVote);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("Vote失敗" + ex);

			}

			return ApiResult.Success("Vote成功");
		}

		// POST: api/PostComments
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ApiResult> CreartePostComment(CommentCreateDto dto)
		{
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用
			if (memberId == 0)
			{
				return ApiResult.Fail("沒這個會員");
			}

			PostComment newPost = new PostComment
			{
				Id = 0,
				MemberId = memberId,
				PostId = dto.PostId,
				Content = dto.Content,
				Datetime = DateTime.Now,
				ActiveFlag = true
			};
			try
			{
				_context.PostComments.Add(newPost);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				return ApiResult.Fail("發布失敗");
			}

			return ApiResult.Success("發布成功");
		}

		// DELETE: api/PostComments/5
		[HttpDelete("{id}")]
		public async Task<ApiResult> DeletePostComment(int id)
		{
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用

			PostComment existingEntity = _context.PostComments.Find(id);

			if (existingEntity == null)
			{
				return ApiResult.Fail("找不到這篇Psot,刪除失敗");
			}

			if (memberId != existingEntity.MemberId && _simpleHelper.IsBoadMod(existingEntity.Post.BoardId ?? 0, memberId))
			{
				return ApiResult.Fail("刪除失敗，本人或板手才可以刪除");
			}

			try
			{
				existingEntity.DeleteDatetime = DateTime.Now;
				existingEntity.DeleteMemberId = memberId;
				existingEntity.ActiveFlag = false;
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				return ApiResult.Fail("刪除失敗");
			}

			return ApiResult.Success("刪除成功");
		}

		private bool PostCommentExists(int id)
		{
			return (_context.PostComments?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
