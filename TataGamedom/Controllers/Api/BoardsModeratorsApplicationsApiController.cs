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
    public class BoardsModeratorsApplicationsApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/BoardsModeratorsApplicationsApi
        public IQueryable<BoardsModeratorsApplication> GetBoardsModeratorsApplications()
        {
            return db.BoardsModeratorsApplications;
        }

        // GET: api/BoardsModeratorsApplicationsApi/5
        [ResponseType(typeof(BoardsModeratorsApplication))]
        public IHttpActionResult GetBoardsModeratorsApplication(int id)
        {
            BoardsModeratorsApplication boardsModeratorsApplication = db.BoardsModeratorsApplications.Find(id);
            if (boardsModeratorsApplication == null)
            {
                return NotFound();
            }

            return Ok(boardsModeratorsApplication);
        }

        // PUT: api/BoardsModeratorsApplicationsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoardsModeratorsApplication(int id, BoardsModeratorsApplication boardsModeratorsApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardsModeratorsApplication.Id)
            {
                return BadRequest();
            }

            db.Entry(boardsModeratorsApplication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardsModeratorsApplicationExists(id))
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

        // POST: api/BoardsModeratorsApplicationsApi
        [ResponseType(typeof(BoardsModeratorsApplication))]
        public IHttpActionResult PostBoardsModeratorsApplication(BoardsModeratorsApplication boardsModeratorsApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BoardsModeratorsApplications.Add(boardsModeratorsApplication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = boardsModeratorsApplication.Id }, boardsModeratorsApplication);
        }

        // DELETE: api/BoardsModeratorsApplicationsApi/5
        [ResponseType(typeof(BoardsModeratorsApplication))]
        public IHttpActionResult DeleteBoardsModeratorsApplication(int id)
        {
            BoardsModeratorsApplication boardsModeratorsApplication = db.BoardsModeratorsApplications.Find(id);
            if (boardsModeratorsApplication == null)
            {
                return NotFound();
            }

            db.BoardsModeratorsApplications.Remove(boardsModeratorsApplication);
            db.SaveChanges();

            return Ok(boardsModeratorsApplication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardsModeratorsApplicationExists(int id)
        {
            return db.BoardsModeratorsApplications.Count(e => e.Id == id) > 0;
        }
    }
}