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
    public class FrontPostReportsApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        //// GET: api/FrontPostReportsApi
        //public IQueryable<PostReport> GetPostReports()
        //{
        //    return db.PostReports;
        //}

        //// GET: api/FrontPostReportsApi/5
        //[ResponseType(typeof(PostReport))]
        //public IHttpActionResult GetPostReport(int id)
        //{
        //    PostReport postReport = db.PostReports.Find(id);
        //    if (postReport == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(postReport);
        //}

        //// PUT: api/FrontPostReportsApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPostReport(int id, PostReport postReport)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != postReport.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(postReport).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PostReportExists(id))
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

        //// POST: api/FrontPostReportsApi
        //[ResponseType(typeof(PostReport))]
        //public IHttpActionResult PostPostReport(PostReport postReport)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PostReports.Add(postReport);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = postReport.Id }, postReport);
        //}

        //// DELETE: api/FrontPostReportsApi/5
        //[ResponseType(typeof(PostReport))]
        //public IHttpActionResult DeletePostReport(int id)
        //{
        //    PostReport postReport = db.PostReports.Find(id);
        //    if (postReport == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PostReports.Remove(postReport);
        //    db.SaveChanges();

        //    return Ok(postReport);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostReportExists(int id)
        {
            return db.PostReports.Count(e => e.Id == id) > 0;
        }
    }
}