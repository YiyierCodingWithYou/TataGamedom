using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TataGamedomWebAPI.Infrastructure;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.DTOs.Post;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Services;


namespace TataGamedomWebAPI.Controllers
{


	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly AppDbContext _context;
		private SimpleHelper _simpleHelper;

		public PostsController(AppDbContext context)
		{
			_context = context;
			_simpleHelper = new SimpleHelper(_context);
		}

		// GET: api/Posts
		[EnableCors("AllowCookie")]
		[HttpGet("{postId}")]
		public async Task<PostReadDto> GetPosts(int? postId)
		{
			var account = HttpContext.User.FindFirstValue("MembersAccount");
			int? memberId = _simpleHelper.memberIdByAccount(account);
			//int? memberId = 3; // 王五 wangwu 測試用

			PostReadDto postDto = await _context.Posts.Where(p => p.Id == postId).Select(post =>
			new PostReadDto
			{
				PostId = post.Id,
				Title = post.Title,
				PostContent = post.Content,
				DateTime = post.Datetime,
				BoardId = post.BoardId ?? 0,
				BoardName = post.Board.Name,
				MemberAccount = post.Member.Account,
				MemberId = post.Member.Id,
				MemberName = post.Member.Name,
				VoteUp = post.PostUpDownVotes.Count(v => v.PostId == post.Id && v.Type == true),
				VoteDown = post.PostUpDownVotes.Count(v => v.PostId == post.Id && v.Type == false),
				CommentCount = post.PostComments.Count(c => c.PostId == post.Id && c.ActiveFlag == true),
				IsEdited = (post.LastEditDatetime != post.Datetime),
				LastEditDatetime = post.LastEditDatetime,
				ActiveFlag = post.ActiveFlag
			}).FirstOrDefaultAsync();

			if (postDto == null)
			{
				return null;
			}

			postDto.Comments = GetPostsComments(_context, postDto.PostId, memberId, postDto.BoardId);

			if (memberId != null)
			{
				postDto.IsAuthor = _simpleHelper.PostIsAuthor(postDto.PostId, memberId ?? 0);
				postDto.IsMod = _simpleHelper.IsBoardMod(postDto.BoardId, memberId ?? 0);
				postDto.Voted = _simpleHelper.IsPostVoted(postDto.PostId, memberId ?? 0).voteType;
			}

			return postDto;
		}

		// GET: api/Posts
		[EnableCors("AllowCookie")]
		[HttpGet]
		public async Task<IEnumerable<PostReadDto>> GetPosts(string? keyword, int? postId, string? MemberAccount, int? boardId, int page = 1)
		{
			var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int? memberId = _simpleHelper.memberIdByAccount(memberAccount);

			int pageSize = 5;
			int skipCount = (page - 1) * pageSize;

			var query = _context.Posts.AsQueryable();

			query = query.Where(p => p.ActiveFlag == true);

			if (query == null)
			{
				return null;
			}

			if (!string.IsNullOrWhiteSpace(keyword))
			{
				query = query.Where(p => p.Content.Contains(keyword) || p.Title.Contains(keyword));
			}

			if (postId.HasValue)
			{
				query = query.Where(p => p.Id == postId);
			}

			if (!string.IsNullOrWhiteSpace(MemberAccount))
			{
				query = query.Where(p => p.Member.Account == MemberAccount);
			}

			if (boardId.HasValue)
			{
				query = query.Where(p => p.BoardId == boardId);
			}

			query = query.OrderByDescending(p => p.Datetime);

			query = query.Skip(skipCount).Take(pageSize);

			var posts = await query.Select(p => new PostReadDto
			{
				PostId = p.Id,
				Title = p.Title,
				PostContent = p.Content,
				DateTime = p.Datetime,
				BoardId = p.BoardId ?? 0,
				BoardName = p.Board.Name ?? string.Empty,
				MemberAccount = p.Member.Account,
				MemberId = p.Member.Id,
				MemberName = p.Member.Name,
				VoteUp = p.PostUpDownVotes.Count(v => v.PostId == p.Id && v.Type == true),
				VoteDown = p.PostUpDownVotes.Count(v => v.PostId == p.Id && v.Type == false),
				CommentCount = p.PostComments.Count(c => c.PostId == p.Id && c.ActiveFlag == true),
				IsEdited = (p.LastEditDatetime != p.Datetime),
				LastEditDatetime = p.LastEditDatetime,
				ActiveFlag = p.ActiveFlag
			}).ToListAsync();

			foreach (var post in posts)
			{
				post.Comments = GetPostsComments(_context, post.PostId, memberId, post.BoardId);
			}

			if (memberId != null)
			{
				foreach (var post in posts)
				{
					post.IsAuthor = _simpleHelper.PostIsAuthor(post.PostId, memberId ?? 0);
					post.IsMod = _simpleHelper.IsBoardMod(post.BoardId, memberId ?? 0);
					post.Voted = _simpleHelper.IsPostVoted(post.PostId, memberId ?? 0).voteType;
				}
			}

			return posts;
		}


		// GET: api/Posts
		[EnableCors("AllowCookie")]
		[HttpGet("personalized")]
		public async Task<IEnumerable<PostReadDto>> GetPersonalizedPosts(string? keyword, int? postId, string? MemberAccount, int? boardId, int page = 1)
		{
			var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int? memberId = _simpleHelper.memberIdByAccount(memberAccount);

			int pageSize = 5;
			int skipCount = (page - 1) * pageSize;

			var query = _context.Posts.AsQueryable();
			query = query.Where(p => p.ActiveFlag == true);
			query = query.Where(p => p.Board.MembersBoards.Any(bm => bm.MemberId == memberId) || p.Member.MemberFollowFollowerMembers.Any(m=>m.FollowedMemberId == memberId));

			if (query == null)
			{
				return null;
			}

			if (!string.IsNullOrWhiteSpace(keyword))
			{
				query = query.Where(p => p.Content.Contains(keyword));
			}

			if (postId.HasValue)
			{
				query = query.Where(p => p.Id == postId);
			}

			if (!string.IsNullOrWhiteSpace(MemberAccount))
			{
				query = query.Where(p => p.Member.Account == MemberAccount);
			}

			if (boardId.HasValue)
			{
				query = query.Where(p => p.BoardId == boardId);
			}

			query = query.OrderByDescending(p => p.Datetime);

			query = query.Skip(skipCount).Take(pageSize);

			var posts = await query.Select(p => new PostReadDto
			{
				PostId = p.Id,
				Title = p.Title,
				PostContent = p.Content,
				DateTime = p.Datetime,
				BoardId = p.BoardId ?? 0,
				BoardName = p.Board.Name ?? string.Empty,
				MemberAccount = p.Member.Account,
				MemberId = p.Member.Id,
				MemberName = p.Member.Name,
				VoteUp = p.PostUpDownVotes.Count(v => v.PostId == p.Id && v.Type == true),
				VoteDown = p.PostUpDownVotes.Count(v => v.PostId == p.Id && v.Type == false),
				CommentCount = p.PostComments.Count(c => c.PostId == p.Id && c.ActiveFlag == true),
				IsEdited = (p.LastEditDatetime != p.Datetime),
				LastEditDatetime = p.LastEditDatetime,
				ActiveFlag = p.ActiveFlag
			}).ToListAsync();

			foreach (var post in posts)
			{
				post.Comments = GetPostsComments(_context, post.PostId, memberId, post.BoardId);
			}

			if (memberId != null)
			{
				foreach (var post in posts)
				{
					post.IsAuthor = _simpleHelper.PostIsAuthor(post.PostId, memberId ?? 0);
					post.IsMod = _simpleHelper.IsBoardMod(post.BoardId, memberId ?? 0);
					post.Voted = _simpleHelper.IsPostVoted(post.PostId, memberId ?? 0).voteType;
				}
			}

			return posts;
		}

		private IEnumerable<CommentReadDto> GetPostsComments(AppDbContext context, int postId, int? memberId, int boardId)
		{
			var query = context.PostComments.AsQueryable();
			query = query.Where(p => p.PostId == postId && p.ActiveFlag == true && p.ParentId == null);
			var comments = query.Select(c => new CommentReadDto
			{
				CommentId = c.Id,
				CommentContent = c.Content,
				DateTime = c.Datetime,
				MemberAccount = c.Member.Account,
				MemberName = c.Member.Name,
				VoteUp = c.PostCommentUpDownVotes.Count(v => v.PostCommentId == c.Id && v.Type == true),
				VoteDown = c.PostCommentUpDownVotes.Count(v => v.PostCommentId == c.Id && v.Type == false),
				PostId = c.PostId,
				ActiveFlag = c.ActiveFlag
			})
				.OrderBy(c => c.DateTime)
				.ToList();

			foreach (var comment in comments)
			{
				if (memberId != null)
				{
					comment.IsAuthor = _simpleHelper.CommentIsAuthor(comment.CommentId, memberId ?? 0);
					comment.IsMod = _simpleHelper.IsBoardMod(boardId, memberId ?? 0);
					comment.Voted = _simpleHelper.IsCommentVoted(comment.CommentId, memberId ?? 0).voteType;
				}
				comment.Comments = GetCommentReply(context, comment.CommentId, memberId, boardId);
			}
			return comments;
		}

		private IEnumerable<CommentReadDto> GetCommentReply(AppDbContext context, int commentId, int? memberId, int boardId)
		{
			var query = context.PostComments.AsQueryable();
			query = query.Where(p => p.ParentId == commentId && p.ActiveFlag == true);
			var comments = query.Select(c => new CommentReadDto
			{
				CommentId = c.Id,
				CommentContent = c.Content,
				DateTime = c.Datetime,
				MemberAccount = c.Member.Account,
				MemberName = c.Member.Name,
				VoteUp = c.PostCommentUpDownVotes.Count(v => v.PostCommentId == c.Id && v.Type == true),
				VoteDown = c.PostCommentUpDownVotes.Count(v => v.PostCommentId == c.Id && v.Type == false),
				PostId = c.PostId,
				ActiveFlag = c.ActiveFlag
			})
				.OrderBy(c => c.DateTime)
				.ToList();
			foreach (var comment in comments)
			{
				if (memberId != null)
				{
					comment.IsAuthor = _simpleHelper.CommentIsAuthor(comment.CommentId, memberId ?? 0);
					comment.IsMod = _simpleHelper.IsBoardMod(boardId, memberId ?? 0);
					comment.Voted = _simpleHelper.IsCommentVoted(comment.CommentId, memberId ?? 0).voteType;
				}
				comment.Comments = GetCommentReply(context, comment.CommentId, memberId, boardId);
			}
			return comments;
		}



		[EnableCors("AllowCookie")]
		[HttpPut("{id}")]
		public async Task<ApiResult> EditPost(int id, PostEditoDto dto)
		{
			if (id != dto.Id)
			{
				return ApiResult.Fail("修改失敗");
			}

			Post existingEntity = _context.Posts.Find(id);
			if (existingEntity == null)
			{
				return ApiResult.Fail("修改失敗");
			}


			try
			{
				existingEntity.Title = dto.Title;
				existingEntity.Content = dto.Content;
				existingEntity.LastEditDatetime = DateTime.Now;
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PostExists(id))
				{
					return ApiResult.Fail("修改失敗");
				}
				else
				{
					return ApiResult.Fail("修改失敗");
				}
			}

			return ApiResult.Success("修改成功");
		}


		[EnableCors("AllowCookie")]
		[HttpPut("{postId}/Vote/{voteType}")]
		public async Task<ApiResult> VotePost(int postId, string voteType)
		{
			Post existingPost = _context.Posts.Find(postId);
			var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			//int memberId = 3; // 王五 wangwu 測試用
			var IsVoted = _simpleHelper.IsPostVoted(postId, memberId);

			if (existingPost == null)
			{
				return ApiResult.Fail("不存在該文章");
			}

			if (IsVoted.IsVoted)
			{
				PostUpDownVote vote = _context.PostUpDownVotes.Find(IsVoted.voteId);
				try
				{
					_context.PostUpDownVotes.Remove(vote);
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

			PostUpDownVote newVote = new PostUpDownVote
			{
				Id = 0,
				MemberId = memberId,
				PostId = postId,
				Date = DateTime.Now,
				Type = (voteValue == Vote.Up)
			};

			try
			{
				_context.PostUpDownVotes.Add(newVote);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("Vote失敗" + ex);

			}

			return ApiResult.Success("Vote成功");
		}

		// POST: api/Posts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		[EnableCors("AllowCookie")]
		public async Task<ApiResult> CreatePost(PostCreateDto dto)
		{
			var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			//int memberId = 3; // 王五 wangwu 測試用
			if (memberId == 0)
			{
				return ApiResult.Fail("沒這個會員");
			}

			Post newPost = new Post
			{
				Id = 0,
				MemberId = memberId,
				BoardId = dto.BoardId,
				Title = dto.Title,
				Content = dto.Content,
				Datetime = DateTime.Now,
				LastEditDatetime = DateTime.Now,
				ActiveFlag = true
			};
			//if (_context.Posts == null)
			//{
			//	return Problem("Entity set 'AppDbContext.Posts'  is null.");
			//}
			try
			{
				_context.Posts.Add(newPost);
				await _context.SaveChangesAsync();

			}
			catch (DbUpdateConcurrencyException)
			{
				return ApiResult.Fail("發布失敗");
			}

			return ApiResult.Success("發布成功");
			//return CreatedAtAction("GetPost", new { id = post.Id }, post);
		}


		private bool IsTitleAvailible(string title, string content)
		{
			if (title.Length > 50)
			{
				return false;
			}
			return true;
		}

		private (bool availible, string message) IsContentAvailible(string content)
		{
			if (content.Length > 1500)
			{
				return (false, "長度不可超過1500字");
			}
			if (content.Length == 0)
			{
				return (false, "必須有內容");
			}
			return (true, string.Empty);
		}

		// DELETE: api/Posts/5
		[HttpDelete("{id}")]
		[EnableCors("AllowCookie")]
		public async Task<ApiResult> DeletePost(int id)
		{
			var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			//int memberId = 3; // 王五 wangwu 測試用

			Post existingEntity = _context.Posts.Find(id);

			if (existingEntity == null)
			{
				return ApiResult.Fail("找不到這篇Psot,刪除失敗");
			}

			if (memberId != existingEntity.MemberId && !(_simpleHelper.IsBoardMod(existingEntity.BoardId ?? 0, memberId)))
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

		private bool PostExists(int id)
		{
			return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
