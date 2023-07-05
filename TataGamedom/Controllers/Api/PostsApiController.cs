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
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.ViewModels.PostsComments;

namespace TataGamedom.Controllers
{
	public class PostsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();
		private string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString(); //forDapper
		private SimpleHelper simpleHelper = new SimpleHelper();

		//Complete
		// GET: api/PostsApi
		public IEnumerable<PostsCommentsListVm> GetPostsAndCommntsList()
		{
			using (var connection = new SqlConnection(_connStr))
			{
				connection.Open();

				string query = @"
				SELECT
					bd.Id AS BoardId,
					bd.Name AS BoardName,
                    'Post' AS Type,
                    p.Id AS ID,
                    NULL AS RespondedPost,
                    NULL AS RespondedComment,
                    m.Id AS MemberId,
	                m.Name AS MemberName,
                    p.Content,
                    p.Datetime,
					SUM(CASE WHEN puv.Type = 1 THEN 1 ELSE 0 END) AS LikesCount,
                    SUM(CASE WHEN puv.Type = 0 THEN 1 ELSE 0 END) AS UnlikesCount,
                    COUNT(DISTINCT pc.Id) AS CommentsCount,
                    p.ActiveFlag, 
					p.DeleteDatetime, 
					p.DeleteBackendMemberId, 
					p.DeleteMemberId

                FROM
                    Posts p
                    JOIN Members m ON p.MemberId = m.Id
                    JOIN Boards bd ON p.BoardId = bd.Id
                    LEFT JOIN PostUpDownVotes puv ON p.Id = puv.PostId
                    LEFT JOIN PostComments pc ON p.Id = pc.PostId
                GROUP BY
                    bd.Id, bd.Name, p.Id, m.Id, m.Name, p.Content, p.BoardId, p.Datetime, p.ActiveFlag, p.DeleteDatetime, p.DeleteBackendMemberId, p.DeleteMemberId

                UNION ALL

                SELECT
					bd.Id AS BoardName,
					bd.Name AS BoardName,
                    'Comment' AS Type,
                    pc.Id AS ID,
                    p.Id AS RespondedPost,
                    pc.ParentId AS RespondedComment,
                    m.Id AS MemberId,
	                m.Name AS MemberName,
                    pc.Content,
                    pc.Datetime,
					SUM(CASE WHEN pcuv.Type = 1 THEN 1 ELSE 0 END) AS LikesCount,
                    SUM(CASE WHEN pcuv.Type = 0 THEN 1 ELSE 0 END) AS UnlikesCount,
                   (SELECT COUNT(*) -- 子查詢計算該評論的所有子評論數量
					FROM PostComments pc_sub
					WHERE pc_sub.ParentId = pc.Id				) AS CommentsCount,
                    pc.ActiveFlag,
					pc.DeleteDatetime, 
					pc.DeleteBackendMemberId, 
					pc.DeleteMemberId
                FROM
                    PostComments pc
                    JOIN Members m ON pc.MemberId = m.Id
                    JOIN Posts p ON pc.PostId = p.Id
					JOIN Boards bd ON p.BoardId = bd.Id
                    LEFT JOIN PostCommentUpDownVotes pcuv ON pc.Id = pcuv.PostCommentId
                    LEFT JOIN PostComments pc_parent ON pc.ParentId = pc_parent.Id
                GROUP BY
					bd.Id, bd.Name, pc.Id, p.Id, m.Id, m.Name, pc.Content, pc.ParentId, pc.Datetime, pc.DeleteDatetime, pc.DeleteBackendMemberId, pc.DeleteMemberId, pc.ActiveFlag

				Order by
					Datetime desc
                ";


				//var result = connection.Query<PostsAndCommntsListDto>(query);

				//return result;

				IEnumerable<PostsCommentsListVm> result = connection.Query<PostsCommentsListVm>(query);
				return result;
			}
		}

		// GET: api/PostsApi/5
		//[ResponseType(typeof(Post))]
		//public IHttpActionResult GetPost(int id)
		//{
		//	Post post = db.Posts.Find(id);
		//	if (post == null)
		//	{
		//		return NotFound();
		//	}

		//	return Ok(post);
		//}



		//PUT: api/PostsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult PutRecoverPost(int id)
		{
			Post post = db.Posts.Find(id);
			if (post == null)
			{
				return ApiResult.Fail("復原失敗");
			}

			if(post.ActiveFlag == true)
			{
				return ApiResult.Fail("此非被刪除的貼文");
			}

			if (post.DeleteMemberId == post.MemberId)
			{
				return ApiResult.Fail("不能還原自刪的文");
			}

			try
			{
				post.ActiveFlag = true;
				post.DeleteDatetime = null;
				post.DeleteBackendMemberId = null;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("還原失敗" + ex.Message);
			}
			db.SaveChanges();

			return ApiResult.Success("還原成功");

		}

		// POST: api/PostsApi
		//[ResponseType(typeof(Post))]
		//public IHttpActionResult PostPost(Post post)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	db.Posts.Add(post);
		//	db.SaveChanges();

		//	return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
		//}

		// DELETE: api/PostsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult DeleteActiveFlagChangePost(int id)
		{

			var backendMemberAccount = User.Identity.Name;
			//int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);
			int backendMemberId = 1;

			Post post = db.Posts.Find(id);
			if (post == null)
			{
				return ApiResult.Fail("刪除失敗");
			}
			try
			{
				post.ActiveFlag = false;
				post.DeleteDatetime = DateTime.Now;
				post.DeleteBackendMemberId = backendMemberId;
				db.SaveChanges();
			}catch (DbUpdateConcurrencyException ex) {
			
				return ApiResult.Fail("刪除失敗"+ex.Message);
			}
			db.SaveChanges();

			return ApiResult.Success("刪除成功");
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