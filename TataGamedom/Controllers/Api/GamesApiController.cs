using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.Games;

namespace TataGamedom.Controllers.Api
{
    public class GamesApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();

		// GET: api/GamesApi/5
        public async Task<IEnumerable<GameIndexVM>> GetGamesList()
        {
			IEnumerable<GameIndexVM> games = await GetGames();
			return games;
		}

		private async Task<IEnumerable<GameIndexVM>> GetGames()
		{
			return await Task.Run(() =>
			{
				IGameRepository repo = new GameDapperRepository();
				GameService service = new GameService(repo);
				return service.Search();
			});
		}

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
					return ApiResult.Fail("無法刪除該遊戲，因" + ex.Message + "，請聯繫工程師 :) ");
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