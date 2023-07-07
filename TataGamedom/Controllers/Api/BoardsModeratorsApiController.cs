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
    public class BoardsModeratorsApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/BoardsModeratorsApi
        public IQueryable<BoardsModerator> GetBoardsModerators()
        {
            return db.BoardsModerators;
        }

        // GET: api/BoardsModeratorsApi/5
        [ResponseType(typeof(BoardsModerator))]
        public IHttpActionResult GetBoardsModerator(int id)
        {
            BoardsModerator boardsModerator = db.BoardsModerators.Find(id);
            if (boardsModerator == null)
            {
                return NotFound();
            }

            return Ok(boardsModerator);
        }

        // PUT: api/BoardsModeratorsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoardsModerator(int id, BoardsModerator boardsModerator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardsModerator.Id)
            {
                return BadRequest();
            }

            db.Entry(boardsModerator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardsModeratorExists(id))
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

        // POST: api/BoardsModeratorsApi
        [ResponseType(typeof(BoardsModerator))]
        public IHttpActionResult PostBoardsModerator(BoardsModerator boardsModerator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BoardsModerators.Add(boardsModerator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = boardsModerator.Id }, boardsModerator);
        }

        // DELETE: api/BoardsModeratorsApi/5
        [ResponseType(typeof(BoardsModerator))]
        public IHttpActionResult DeleteBoardsModerator(int id)
        {
            BoardsModerator boardsModerator = db.BoardsModerators.Find(id);
            if (boardsModerator == null)
            {
                return NotFound();
            }

            db.BoardsModerators.Remove(boardsModerator);
            db.SaveChanges();

            return Ok(boardsModerator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardsModeratorExists(int id)
        {
            return db.BoardsModerators.Count(e => e.Id == id) > 0;
        }
    }
}