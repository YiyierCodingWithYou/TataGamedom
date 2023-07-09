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
using TataGamedom.Models.ViewModels.BoardsModerators;

namespace TataGamedom.Controllers.Api
{
    public class BoardsModeratorsApiController : ApiController
    {
        private AppDbContext db = new AppDbContext();
		private string _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ToString(); //forDapper
		private SimpleHelper simpleHelper = new SimpleHelper();

		// GET: api/BoardsModeratorsApi
		public IEnumerable<BoardsModeratorListVm> GetBoardsModerators()
        {
            if (db.BoardsModerators==null)
            {
                return null;
            }
            return db.BoardsModerators.Select(m => new BoardsModeratorListVm
            {
                Id = m.Id,
                BoardName = m.Board.Name,
                MemberAccount = m.Member.Account,
                LastOnlineTime = m.Member.LastOnlineTime??DateTime.MinValue,
                StartDate = m.StartDate,
                EndDate = m.EndDate,
                Status = m.EndDate < DateTime.Now ? "退職" : "在職"
            });

		}

		// GET: api/BoardsModeratorsApi/5
		[ResponseType(typeof(IEnumerable<String>))]
		public IEnumerable<String> GetBoardsModerator(int boardId)
        {
			IEnumerable<string> boardsModerators = db.BoardsModerators
				.Where(bm => bm.BoardId == boardId)
				.Select(bm => bm.Member.Name)
				.ToList();

			return boardsModerators;
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
        [ResponseType(typeof(ApiResult))]
        public ApiResult PostBoardsModerator(BoardsModeratorAddVm vm)
        {
            int memberId = simpleHelper.memberIdByAccount(vm.MemberAccount);
			int boardId = simpleHelper.boardIdByName(vm.BoardName);


			if (db.BoardsModerators.Any(x => x.ModeratorMemberId == memberId))
            {
                return ApiResult.Fail("已經是版主了，不能再加囉!");
            }

			if (db.BoardsModerators.Count(x => x.BoardId == boardId ) >= 3)
			{
				return ApiResult.Fail("每版版主最多三人，不能再加囉!");
			}

			BoardsModerator mod = new BoardsModerator
            {
                ModeratorMemberId = memberId,
                BoardId = boardId,
				StartDate = DateTime.Now,
                EndDate = null
			};

			try
			{
				db.BoardsModerators.Add(mod);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("新增失敗：" + ex.Message);
			}
			return ApiResult.Success("新增成功");
		}

        // DELETE: api/BoardsModeratorsApi/5
        [ResponseType(typeof(ApiResult))]
        public ApiResult DeleteBoardsModerator(int id)
        {
			BoardsModerator entity = db.BoardsModerators.Find(id);

			if (entity == null)
			{
				return ApiResult.Fail("刪除失敗");
			}

			if (entity.EndDate <= DateTime.Now)
			{
				return ApiResult.Fail("早就離職了啦");
			}

			try
			{
				entity.EndDate = DateTime.Now;
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("解職失敗：" + ex.Message);
			}

			return ApiResult.Success("解職成功");
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