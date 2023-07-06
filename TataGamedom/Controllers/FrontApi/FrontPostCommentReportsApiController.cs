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

namespace TataGamedom.Controllers.FrontApi
{
    public class FrontPostCommentReportsApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/FrontPostCommentReportsApi
        //public IQueryable<PostCommentReport> GetPostCommentReports()
        //{
        //    return db.PostCommentReports;
        //}

        //// GET: api/FrontPostCommentReportsApi/5
        //[ResponseType(typeof(PostCommentReport))]
        //public IHttpActionResult GetPostCommentReport(int id)
        //{
        //    PostCommentReport postCommentReport = db.PostCommentReports.Find(id);
        //    if (postCommentReport == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(postCommentReport);
        //}

        //// PUT: api/FrontPostCommentReportsApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPostCommentReport(int id, PostCommentReport postCommentReport)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != postCommentReport.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(postCommentReport).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PostCommentReportExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/FrontPostCommentReportsApi
        //[ResponseType(typeof(PostCommentReport))]
        //public IHttpActionResult PostPostCommentReport(PostCommentReport postCommentReport)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PostCommentReports.Add(postCommentReport);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = postCommentReport.Id }, postCommentReport);
        //}

        //// DELETE: api/FrontPostCommentReportsApi/5
        //[ResponseType(typeof(PostCommentReport))]
        //public IHttpActionResult DeletePostCommentReport(int id)
        //{
        //    PostCommentReport postCommentReport = db.PostCommentReports.Find(id);
        //    if (postCommentReport == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PostCommentReports.Remove(postCommentReport);
        //    db.SaveChanges();

        //    return Ok(postCommentReport);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostCommentReportExists(int id)
        {
            return db.PostCommentReports.Count(e => e.Id == id) > 0;
        }
    }
}