using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;
using TataGamedomWebAPI.Models.Services;

namespace TataGamedomWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public PostsController(AppDbContext context)
		{
			_context = context;
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


		//// GET: aci/Posts/5
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
		public async Task<IActionResult> PutPost(int id, Post post)
		{
			if (id != post.Id)
			{
				return BadRequest();
			}

			_context.Entry(post).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PostExists(id))
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

		// POST: api/Posts
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Post>> PostPost(Post post)
		{
			if (_context.Posts == null)
			{
				return Problem("Entity set 'AppDbContext.Posts'  is null.");
			}
			_context.Posts.Add(post);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetPost", new { id = post.Id }, post);
		}

		// DELETE: api/Posts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePost(int id)
		{
			if (_context.Posts == null)
			{
				return NotFound();
			}
			var post = await _context.Posts.FindAsync(id);
			if (post == null)
			{
				return NotFound();
			}

			_context.Posts.Remove(post);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PostExists(int id)
		{
			return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
