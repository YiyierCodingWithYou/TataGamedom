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

namespace TataGamedom.Controllers.Api
{
    public class BucketLogsApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/BucketLogsApi
        public IQueryable<BucketLog> GetBucketLogs()
        {
            return db.BucketLogs;
        }

        // GET: api/BucketLogsApi/5
        [ResponseType(typeof(BucketLog))]
        public IHttpActionResult GetBucketLog(int id)
        {
            BucketLog bucketLog = db.BucketLogs.Find(id);
            if (bucketLog == null)
            {
                return NotFound();
            }

            return Ok(bucketLog);
        }

        // PUT: api/BucketLogsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBucketLog(int id, BucketLog bucketLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bucketLog.Id)
            {
                return BadRequest();
            }

            db.Entry(bucketLog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BucketLogExists(id))
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

        // POST: api/BucketLogsApi
        [ResponseType(typeof(BucketLog))]
        public IHttpActionResult PostBucketLog(BucketLog bucketLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BucketLogs.Add(bucketLog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bucketLog.Id }, bucketLog);
        }

        // DELETE: api/BucketLogsApi/5
        [ResponseType(typeof(BucketLog))]
        public IHttpActionResult DeleteBucketLog(int id)
        {
            BucketLog bucketLog = db.BucketLogs.Find(id);
            if (bucketLog == null)
            {
                return NotFound();
            }

            db.BucketLogs.Remove(bucketLog);
            db.SaveChanges();

            return Ok(bucketLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BucketLogExists(int id)
        {
            return db.BucketLogs.Count(e => e.Id == id) > 0;
        }
    }
}