using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;

namespace TataGamedom.Controllers.Api
{
	public class CommentsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();
		private string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString(); //forDapper
		private SimpleHelper simpleHelper = new SimpleHelper();




		//// GET: api/CommentsApi
		//public IQueryable<PostComment> GetPostComments()
		//      {
		//          return db.PostComments;
		//      }

		//      // GET: api/CommentsApi/5
		//      [ResponseType(typeof(PostComment))]
		//      public IHttpActionResult GetPostComment(int id)
		//      {
		//          PostComment postComment = db.PostComments.Find(id);
		//          if (postComment == null)
		//          {
		//              return NotFound();
		//          }

		//          return Ok(postComment);
		//      }



		// PUT: api/CommentsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult PutRecoverComment(int id)
		{
			PostComment comment = db.PostComments.Find(id);

			if (comment == null)
			{
				return ApiResult.Fail("復原失敗");
			}

			if (comment.ActiveFlag == true)
			{
				return ApiResult.Fail("此非被刪除的留言");
			}

			if (comment.DeleteMemberId == comment.MemberId)
			{
				return ApiResult.Fail("不能還原自刪的留言");
			}

			try
			{
				comment.ActiveFlag = true;
				comment.DeleteDatetime = null;
				comment.DeleteBackendMemberId = null;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("還原失敗" + ex.Message);
			}
			db.SaveChanges();

			return ApiResult.Success("還原成功");

		}

		//      // POST: api/CommentsApi
		//      [ResponseType(typeof(PostComment))]
		//      public IHttpActionResult PostPostComment(PostComment postComment)
		//      {
		//          if (!ModelState.IsValid)
		//          {
		//              return BadRequest(ModelState);
		//          }

		//          db.PostComments.Add(postComment);
		//          db.SaveChanges();

		//          return CreatedAtRoute("DefaultApi", new { id = postComment.Id }, postComment);
		//      }

		 // DELETE: api/CommentsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult DeleteActiveFlagChangeComment(int id)
		{

			var backendMemberAccount = User.Identity.Name;
			int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);
			//int backendMemberId = 1;

			PostComment comment = db.PostComments.Find(id);
			if (comment == null)
			{
				return ApiResult.Fail("刪除失敗");
			}
			try
			{
				comment.ActiveFlag = false;
				comment.DeleteDatetime = DateTime.Now;
				comment.DeleteBackendMemberId = backendMemberId;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{

				return ApiResult.Fail("刪除失敗" + ex.Message);
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

		private bool PostCommentExists(int id)
		{
			return db.PostComments.Count(e => e.Id == id) > 0;
		}
	}
}