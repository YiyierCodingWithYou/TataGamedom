using DocumentFormat.OpenXml.Wordprocessing;
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
using System.Web.Http.Results;
using System.Web.Services.Description;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.ViewModels.BoardsModerators;

namespace TataGamedom.Controllers.Api
{
	public class BoardsModeratorsApplicationsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();
		private SimpleHelper simpleHelper = new SimpleHelper();

		// GET: api/BoardsModeratorsApplicationsApi/NApprovalNum
		[System.Web.Http.HttpGet]
		[System.Web.Http.Route("api/BoardsModeratorsApplicationsApi/NApprovalNum")]
		public int GetCountNullApprovalResult()
		{
			int count = db.BoardsModeratorsApplications.Count(m => m.ApprovalResult == null);
			return count;
		}

		// GET: api/BoardsModeratorsApplicationsApi
		public IEnumerable<BoardsModeratorsApplicationListVm> GetBoardsModeratorsApplications()
		{
			if (db.BoardsModeratorsApplications == null)
			{
				return null;
			}
			return db.BoardsModeratorsApplications.Select(m => new BoardsModeratorsApplicationListVm
			{
				Id = m.Id,
				MemberAccount = m.Member.Account,
				BoardName = m.Board.Name,
				ApplyDate = m.ApplyDate,
				AddOrRemove = m.AddOrRemove,
				AddOrRemoveText = m.AddOrRemove ? "加入" : "離職",
				ApplyReason = m.ApplyReason,
				ApprovalStatus = (m.ApprovalResult == null)?"待處理":"已完成",
				ApprovalResult = m.ApprovalResult,
				ApprovalResultText = m.ApprovalResult == true ? "允許" : (m.ApprovalResult == false ? "拒絕" : "尚未審查"),
				BackendMemberAccount = m.BackendMember.Account??"尚未審查",
				ApprovalStatusDate = m.ApprovalStatusDate ?? null
			});
		}

		//PUT: api/BoardsModeratorsApplicationsApi/Join/5
		[System.Web.Http.HttpPut]
		[System.Web.Http.Route("api/BoardsModeratorsApplicationsApi/Join/{id}")]
		[ResponseType(typeof(ApiResult))]
		public ApiResult PutBoardsModeratorsApplicationJoin(int id, BoardsModeratorsApplicationSubmitVm vm)
		{
			var backendMemberAccount = User.Identity.Name;
			//int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);
			int backendMemberId = 1;


			BoardsModeratorsApplication modApplication = db.BoardsModeratorsApplications.Find(id);

			if (modApplication == null)
			{
				return ApiResult.Fail("Id錯誤");
			}

			if (modApplication.ApprovalResult != null)
			{
				return ApiResult.Fail("已經審核過啦");
			}

			try
			{
				modApplication.ApprovalResult = vm.ApprovalResult;
				modApplication.BackendMemberId = backendMemberId;
				modApplication.ApprovalStatusDate = DateTime.Now;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("確認失敗，原因: " + ex);
			}

			if (!vm.ApprovalResult)
			{
				//寄信，告知感謝他的貢獻
				try
				{
					modApplication.ApprovalResult = vm.ApprovalResult;
					db.SaveChanges();
				}
				catch (DbUpdateConcurrencyException ex)
				{
					return ApiResult.Fail("處理過程中發生錯誤: " + ex);
				}
				return ApiResult.Success("完成確認，拒絕申請");
			}
			else
			{

				BoardsModeratorsApiController modApi = new BoardsModeratorsApiController();
				BoardsModeratorAddVm addModVm = new BoardsModeratorAddVm
				{
					BoardName = vm.BoardName,
					MemberAccount = vm.MemberAccount
				};

				ApiResult addMod = modApi.PostBoardsModerator(addModVm);

				if (addMod.IsFail)
				{
					try
					{
						modApplication.ApprovalResult = null;
						modApplication.BackendMemberId = null;
						modApplication.ApprovalStatusDate = null;
						db.SaveChanges();
					}
					catch (DbUpdateConcurrencyException ex)
					{
						return ApiResult.Fail("處理過程中發生錯誤: " + ex);
					}

					return ApiResult.Fail("不能再新增版主惹！" + addMod.Message);
				}

				//寄信
				return ApiResult.Success("完成接受申請，並新增版主");
			}

		}

		//PUT: api/BoardsModeratorsApplicationsApi/Left/5
		[System.Web.Http.HttpPut]
		[System.Web.Http.Route("api/BoardsModeratorsApplicationsApi/Left/{id}")]
		[ResponseType(typeof(ApiResult))]
		public ApiResult PutBoardsModeratorsApplicationLeft(int id, BoardsModeratorsApplicationSubmitVm vm)
		{
			var backendMemberAccount = User.Identity.Name;
			//int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);
			int backendMemberId = 1;

			BoardsModeratorsApplication modApplication = db.BoardsModeratorsApplications.Find(id);


			int memberId = simpleHelper.memberIdByAccount(vm.MemberAccount);
			int boardId = simpleHelper.boardIdByName(vm.BoardName);

			int modId = db.BoardsModerators.Where(x=> x.ModeratorMemberId == memberId && x.BoardId == boardId && x.EndDate == null)
											.Select(x => x.Id).FirstOrDefault();

			if (modApplication == null)
			{
				return ApiResult.Fail("Id錯誤");
			}

			if (modApplication.ApprovalResult != null)
			{
				return ApiResult.Fail("已經審核過啦");
			}

			try
			{
				modApplication.ApprovalResult = true;
				modApplication.BackendMemberId = backendMemberId;
				modApplication.ApprovalStatusDate = DateTime.Now;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				return ApiResult.Fail("確認失敗，原因: " + ex);
			}



			BoardsModeratorsApiController modApi = new BoardsModeratorsApiController();
			ApiResult deleMod = modApi.DeleteBoardsModerator(modId);
			if (deleMod.IsFail)
			{
				try
				{
					modApplication.ApprovalResult = null;
					modApplication.BackendMemberId = null;
					modApplication.ApprovalStatusDate = null;
					db.SaveChanges();
				}
				catch (DbUpdateConcurrencyException ex)
				{
					return ApiResult.Fail("處理過程中發生錯誤: " + ex);
				}

				return ApiResult.Fail("有點錯誤" + deleMod.Message);
			}

			//寄信
			return ApiResult.Success("完成接受申請，已經讓版主好好退休");
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

// GET: api/BoardsModeratorsApplicationsApi/5
//[ResponseType(typeof(BoardsModeratorsApplication))]
//public IHttpActionResult GetBoardsModeratorsApplication(int id)
//{
//	BoardsModeratorsApplication boardsModeratorsApplication = db.BoardsModeratorsApplications.Find(id);
//	if (boardsModeratorsApplication == null)
//	{
//		return NotFound();
//	}

//	return Ok(boardsModeratorsApplication);
//}