using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		[HttpGet]
		public async Task<IEnumerable<PostReadDto>> GetPosts(string? keyword, int? postId, string? MemberAccount, string? BoardName, int page = 1)
		{

			int pageSize = 3;
			int skipCount = (page - 1) * pageSize;

			var query = _context.Posts.AsQueryable();

			query = query.Where(p => p.ActiveFlag == true);

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

			if (!string.IsNullOrWhiteSpace(BoardName))
			{
				query = query.Where(p => p.Board.Name == BoardName);
			}

			query = query.OrderByDescending(p => p.Datetime);

			query = query.Skip(skipCount).Take(pageSize);

			var posts = await query.Select(p => new PostReadDto
			{
				PostId = p.Id,
				Title = p.Title,
				PostContent = p.Content,
				DateTime = p.Datetime,
				BoardId = p.BoardId??0,
				BoardName = p.Board.Name??string.Empty,
				MemberAccount = p.Member.Account,
				MemberName = p.Member.Name,
				VoteUp = p.PostUpDownVotes.Count(v => v.PostId == p.Id && v.Type == true),
				VoteDown = p.PostUpDownVotes.Count(v => v.PostId == p.Id && v.Type == false),
				CommentCount = p.PostComments.Count(c => c.PostId == p.Id && c.ActiveFlag == true),
				IsEdited = (p.LastEditDatetime != p.Datetime),
				LastEditDatetime = p.LastEditDatetime

			}).ToListAsync();

			foreach (var post in posts)
			{
				post.Comments = GetPostsComments(_context, post.PostId);
			}

			return posts;
		}

		private IEnumerable<CommentReadDto> GetPostsComments(AppDbContext context, int postId)
		{
			var query = context.PostComments.AsQueryable();
			query = query.Where(p => p.PostId == postId && p.ActiveFlag==true);
			var comments = query.Select(c => new CommentReadDto
			{
				CommentId = c.Id,
				CommentContent = c.Content,
				DateTime = c.Datetime,
				MemberAccount = c.Member.Account,
				MemberName = c.Member.Name,
				VoteUp = c.PostCommentUpDownVotes.Count(v => v.PostCommentId == c.Id && v.Type == true),
				VoteDown = c.PostCommentUpDownVotes.Count(v => v.PostCommentId == c.Id && v.Type == false),
			}).ToList();

			return comments;
		}


		// GET: aci/Posts/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Post>> GetPost(int id)
		//{
		//	if (_context.Posts == null)
		//	{
		//		return NotFound();
		//	}
		//	var post = await _context.Posts.FindAsync(id);

		//	if (post == null)
		//	{
		//		return NotFound();
		//	}

		//	return post;
		//}


		// PUT: api/Posts/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

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

		[HttpPut("{postId}/Vote/{voteType}")]
		public async Task<ApiResult> VotePost(int postId, string voteType)
		{
			Post existingPost = _context.Posts.Find(postId);
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用
			var IsVoted = _simpleHelper.IsPostVoted(postId, memberId);

			if (existingPost == null)
			{
				return ApiResult.Fail("不存在該文章");
			}

			if(IsVoted.IsVoted)
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

			PostUpDownVote newVote= new PostUpDownVote
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
				}catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("Vote失敗"+ex);

				}

			return ApiResult.Success("Vote成功");
		}

		// POST: api/Posts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ApiResult> CreatePost(PostCreateDto dto)
		{
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用
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

			}catch (DbUpdateConcurrencyException)
			{
				return ApiResult.Fail("發布失敗");
			}

			return ApiResult.Success("發布成功");
			//return CreatedAtAction("GetPost", new { id = post.Id }, post);
		}

		// DELETE: api/Posts/5
		[HttpDelete("{id}")]
		public async Task<ApiResult> DeletePost(int id)
		{
			//var memberAccount = HttpContext.User.FindFirstValue(ClaimTypes.Name);
			//int memberId = _simpleHelper.memberIdByAccount(memberAccount);
			int memberId = 3; // 王五 wangwu 測試用

			Post existingEntity = _context.Posts.Find(id);

			if (existingEntity == null)
			{
				return ApiResult.Fail("找不到這篇Psot,刪除失敗");
			}

			if ( memberId != existingEntity.MemberId &&  _simpleHelper.IsBoadMod(existingEntity.BoardId??0 , memberId) ) 
			{
				return ApiResult.Fail("刪除失敗，本人或板手才可以刪除");
			}

			try
			{
				existingEntity.DeleteDatetime = DateTime.Now;
				existingEntity.DeleteMemberId = memberId;
				existingEntity.ActiveFlag = false;
				await _context.SaveChangesAsync();
			}catch (DbUpdateConcurrencyException)
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
