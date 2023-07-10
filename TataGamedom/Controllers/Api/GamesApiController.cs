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
    public class GamesApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET: api/GamesApi
        //public IQueryable<Game> GetGames()
        //{
        //    return db.Games;
        //}

        //// GET: api/GamesApi/5
        //[ResponseType(typeof(Game))]
        //public IHttpActionResult GetGame(int id)
        //{
        //    Game game = db.Games.Find(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(game);
        //}

        //// PUT: api/GamesApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutGame(int id, Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != game.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(game).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GameExists(id))
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

        //// POST: api/GamesApi
        //[ResponseType(typeof(Game))]
        //public IHttpActionResult PostGame(Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Games.Add(game);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        //}

        // DELETE: api/GamesApi/5
        [ResponseType(typeof(ApiResult))]
        public ApiResult DeleteGame(int id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return ApiResult.Fail("該遊戲不存在！");
            }
			var gameHasPosts = db.Posts.Any(post => post.Board.GameId == id);
			if (gameHasPosts)
			{
				// 如果該遊戲有貼文，則無法刪除
				return ApiResult.Fail("該遊戲之討論版內尚有用戶貼文，故無法刪除！");
			}
			else
			{
				// 如果該遊戲沒有貼文=>先刪除討論版
				var board = db.Boards.SingleOrDefault(b => b.GameId == id);
				if (board != null)
				{
					db.Boards.Remove(board);
				}
                // =>刪除遊戲類別
				List<GameClassificationGame> classification = db.GameClassificationGames.Where(c => c.GameId == id).ToList();
				db.GameClassificationGames.RemoveRange(classification);
				try
                {
					// =>刪除遊戲
					db.Games.Remove(game);
					db.SaveChanges();
				}
				catch (Exception ex)
                {
					return ApiResult.Fail("無法刪除該遊戲，因為它與其他資料有關聯，請聯繫工程師 :) ");
				}		
			}
            return ApiResult.Success("遊戲刪除成功！");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}