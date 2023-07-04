using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TataGamedom.Models.Dtos.PostsComments;
using TataGamedom.Models.EFModels;

namespace TataGamedom.Controllers
{
	public class PostsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();

		private string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();

		// GET: api/PostsApi
		public IEnumerable<PostsAndCommentsListDto> GetPostsAndCommntsList()
		{
			using (var connection = new SqlConnection(_connStr))
			{
				connection.Open();

				string query = @"
                SELECT
                    'Post' AS Type,
                    p.Id AS ID,
                    NULL AS RespondedPost,
                    NULL AS RespondedComment,
                    m.Id AS MemberId,
	                m.Name AS MemberName,
                    p.Content,
                    p.Datetime,
                    p.ActiveFlag,
                    SUM(CASE WHEN puv.Type = 1 THEN 1 ELSE 0 END) AS LikesCount,
                    SUM(CASE WHEN puv.Type = 0 THEN 1 ELSE 0 END) AS UnlikesCount,
                    COUNT(pc.Id) AS CommentsCount
                FROM
                    Posts p
                    JOIN Members m ON p.MemberId = m.Id
                    LEFT JOIN Boards bd ON p.BoardId = bd.Id
                    LEFT JOIN PostUpDownVotes puv ON p.Id = puv.PostId
                    LEFT JOIN PostComments pc ON p.Id = pc.PostId
                GROUP BY
                    p.Id, m.Id, m.Name, p.Content, p.BoardId, p.Datetime, p.ActiveFlag

                UNION ALL

                SELECT
                    'Comment' AS Type,
                    pc.Id AS ID,
                    p.Id AS RespondedPost,
                    pc.ParentId AS RespondedComment,
                    m.Id AS MemberId,
	                m.Name AS MemberName,
                    pc.Content,
                    pc.Datetime,
                    pc.ActiveFlag,
                    SUM(CASE WHEN pcuv.Type = 1 THEN 1 ELSE 0 END) AS LikesCount,
                    SUM(CASE WHEN pcuv.Type = 0 THEN 1 ELSE 0 END) AS UnlikesCount,
                    COUNT(pc_parent.Id) AS CommentsCount
                FROM
                    PostComments pc
                    JOIN Members m ON pc.MemberId = m.Id
                    JOIN Posts p ON pc.PostId = p.Id
                    LEFT JOIN PostCommentUpDownVotes pcuv ON pc.Id = pcuv.PostCommentId
                    LEFT JOIN PostComments pc_parent ON pc.ParentId = pc_parent.Id
                GROUP BY
                    pc.Id, p.Id, m.Id, m.Name, pc.Content, pc.ParentId, pc.Datetime, pc.ActiveFlag
                ";


				//var result = connection.Query<PostsAndCommntsListDto>(query);

				//return result;

				var result = connection.Query<PostsAndCommentsListDto>(query);
				return result;
			}
		}

		// GET: api/PostsApi/5
		[ResponseType(typeof(Post))]
		public IHttpActionResult GetPost(int id)
		{
			Post post = db.Posts.Find(id);
			if (post == null)
			{
				return NotFound();
			}

			return Ok(post);
		}

		// PUT: api/PostsApi/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutPost(int id, Post post)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != post.Id)
			{
				return BadRequest();
			}

			db.Entry(post).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
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

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/PostsApi
		[ResponseType(typeof(Post))]
		public IHttpActionResult PostPost(Post post)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Posts.Add(post);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
		}

		// DELETE: api/PostsApi/5
		[ResponseType(typeof(Post))]
		public IHttpActionResult DeletePost(int id)
		{
			Post post = db.Posts.Find(id);
			if (post == null)
			{
				return NotFound();
			}

			db.Posts.Remove(post);
			db.SaveChanges();

			return Ok(post);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool PostExists(int id)
		{
			return db.Posts.Count(e => e.Id == id) > 0;
		}
	}

}