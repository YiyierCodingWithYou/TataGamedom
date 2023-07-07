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
using System.Web.Mvc;
using System.Threading.Tasks;
using TataGamedom.Models.Dtos.Boards;
using TataGamedom.Models.ViewModels.Boards;
using TataGamedom.Models.Infra;
using System.IO;
using System.Web;

namespace TataGamedom.Controllers
{
	public class BoardsApiController : ApiController
	{
		private AppDbContext db = new AppDbContext();
		private SimpleHelper simpleHelper = new SimpleHelper();

		// GET: api/BoardsApi
		public async Task<IEnumerable<BoardListVM>> GetBoards()
		{
			if (db.Boards == null)
			{
				return null;
			}
			return db.Boards.Select(board => new BoardListVM
			{
				Id = board.Id,
				BoardHeaderCoverImg = "/Files/Uploads/" + board.BoardHeaderCoverImg,
				Name = board.Name,
				GameName = board.GameId != null ? (board.Game.ChiName + " | " + board.Game.EngName) : "",
				BoardAbout = board.BoardAbout,
				FollowersCount = db.MembersBoards.Count(mb => mb.BoardId == board.Id),
				LastPostedAt = db.Posts.Where(p => p.BoardId == board.Id)
					  .OrderByDescending(p => p.Datetime)
					  .Select(p => p.Datetime)
					  .DefaultIfEmpty(DateTime.MinValue)
					  .FirstOrDefault()
			});
		}

		// GET: api/BoardsApi/5
		[ResponseType(typeof(BoardListVM))]
		public IHttpActionResult GetBoard(int id)
		{
			Board board = db.Boards.Find(id);
			if (board == null)
			{
				return NotFound();
			}
			var vm = new BoardListVM
			{
				Id = board.Id,
				BoardHeaderCoverImg = "/Files/Uploads/" + board.BoardHeaderCoverImg,
				Name = board.Name,
				GameName = board.Game.ChiName + " | " + board.Game.EngName,
				BoardAbout = board.BoardAbout,
				FollowersCount = db.MembersBoards.Count(mb => mb.BoardId == board.Id),
				LastPostedAt = db.Posts.Where(p => p.BoardId == board.Id)
						  .OrderByDescending(p => p.Datetime)
						  .Select(p => p.Datetime)
						  .DefaultIfEmpty(DateTime.MinValue)
						  .FirstOrDefault()
			};

			return Ok(vm);
		}

		// PUT: api/BoardsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult PutBoard(int id, BoardCreateEditorVM vm)
		{
			if (!ModelState.IsValid)
			{
				return ApiResult.Fail("驗證失敗");
			}

			BoardEditDto dto = new BoardEditDto
			{
				Id = vm.Id ?? 0,
				Name = vm.Name,
				BoardAbout = vm.BoardAbout,
			};

			Board existingEntity = db.Boards.Find(id);

			if (id != vm.Id)
			{
				return ApiResult.Fail("修改失敗");
			}

			if (BoardNameExists(dto.Name) && existingEntity.Name != dto.Name)
			{
				return ApiResult.Fail("已經有同名看板");
			}

			try
			{
				existingEntity.Name = dto.Name;
				existingEntity.BoardAbout = dto.BoardAbout;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BoardExists(id))
				{
					return ApiResult.Fail("修改失敗");
				}
				else
				{
					throw;
				}
			}

			return ApiResult.Success("修改成功！");
		}


		// PUT: api/BoardsApi/5/Image
		[System.Web.Http.HttpPut]
		[System.Web.Http.Route("api/BoardsApi/{id}/Image")]
		[ResponseType(typeof(ApiResult))]
		public async Task<ApiResult> PutBoardImg(int id)
		{
			string uniqueFileName = "", BoardHeaderCoverImgPath = "", fileName = "";

			var board = db.Boards.Find(id);
			if (board == null)
			{
				return ApiResult.Fail("NotFound");
			}

			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}

			var uploadFolder = "~/Files/Uploads"; // 指定上傳檔案的儲存位置
			var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath(uploadFolder));

			await Request.Content.ReadAsMultipartAsync(provider);

			if (provider.FileData.Count == 0 || provider.FileData[0] == null || string.IsNullOrEmpty(provider.FileData[0]?.Headers.ContentDisposition.FileName))
			{
				return ApiResult.Fail("說好的檔案呢");
			}

			else
			{
				var fileData = provider.FileData[0];
				fileName = fileData.Headers.ContentDisposition.FileName.Trim('\"');
				var localFilePath = fileData.LocalFileName;
				uniqueFileName = GetUniqueFileName(fileName); // 生成唯一的檔案名


				var destinationFilePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadFolder), uniqueFileName);
				File.Move(localFilePath, destinationFilePath);

				BoardHeaderCoverImgPath = new FileInfo(destinationFilePath)?.FullName;
			}

			var validImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
			var fileExtension = Path.GetExtension(fileName).ToLower();
			if (!validImageExtensions.Contains(fileExtension))
			{
				return ApiResult.Fail("請檢查圖檔");
			}


			BoardEditDto dto = new BoardEditDto
			{
				BoardHeaderCoverImg = uniqueFileName
			};

			Board existingEntity = db.Boards.Find(id);

			var filePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadFolder), dto.BoardHeaderCoverImg);

			try
			{
				File.Move(BoardHeaderCoverImgPath, filePath);
				// 存儲檔案路徑至資料庫中的相應欄位
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("檔案上傳失敗：" + ex.Message);
			}

			try
			{
				existingEntity.BoardHeaderCoverImg = dto.BoardHeaderCoverImg;
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BoardExists(id))
				{
					return ApiResult.Fail("修改失敗");
				}
				else
				{
					throw;
				}
			}

			return ApiResult.Success("修改成功！", "/Files/Uploads/" + existingEntity.BoardHeaderCoverImg);
		}


		// POST: api/BoardsApi
		[ResponseType(typeof(ApiResult))]
		public async Task<ApiResult> PostBoard()
		{
			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}

			var uploadFolder = "~/Files/Uploads"; // 指定上傳檔案的儲存位置
			var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath(uploadFolder));

			await Request.Content.ReadAsMultipartAsync(provider);

			var vm = new BoardCreateEditorVM
			{
				Name = provider.FormData["Name"],
				BoardAbout = provider.FormData["BoardAbout"],
				BoardHeaderCoverImg = null
			};

			string fileName = string.Empty;

			if (provider.FileData.Count > 0)
			{
				var fileData = provider.FileData[0];
				fileName = fileData.Headers.ContentDisposition.FileName.Trim('\"');
				var localFilePath = fileData.LocalFileName;

				var uniqueFileName = GetUniqueFileName(fileName); // 生成唯一的檔案名

				var destinationFilePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadFolder), uniqueFileName);

				File.Move(localFilePath, destinationFilePath);

				vm.BoardHeaderCoverImgPath = new FileInfo(destinationFilePath)?.FullName;
				vm.BoardHeaderCoverImg = uniqueFileName;
			}

			var validImageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
			var fileExtension = Path.GetExtension(fileName).ToLower();
			if (!validImageExtensions.Contains(fileExtension))
			{
				return ApiResult.Fail("新增失敗");
			}


			if (vm == null || !ModelState.IsValid)
			{
				return ApiResult.Fail("新增失敗");
			}

			var backendMemberAccount = User.Identity.Name;
			int backendMemberId = simpleHelper.FindBackendmemberIdByAccount(backendMemberAccount);

			var dto = new BoardCreateDto
			{
				Name = vm.Name,
				BoardAbout = vm.BoardAbout,
				BoardHeaderCoverImg = vm.BoardHeaderCoverImg,
				CreatedBackendMemberId = backendMemberId,
				//CreatedBackendMemberId = 1,
				CreatedTime = DateTime.Now
			};

			if (dto.CreatedBackendMemberId == 0 || BoardNameExists(dto.Name))
			{
				return ApiResult.Fail("新增失敗");
			}

			var filePath = Path.Combine(HttpContext.Current.Server.MapPath(uploadFolder), dto.BoardHeaderCoverImg);

			try
			{
				File.Move(vm.BoardHeaderCoverImgPath, filePath);
				// 存儲檔案路徑至資料庫中的相應欄位
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("檔案上傳失敗：" + ex.Message);
			}

			var entity = new Board
			{
				Name = dto.Name,
				GameId = null,
				BoardAbout = dto.BoardAbout,
				BoardHeaderCoverImg = dto.BoardHeaderCoverImg,
				CreatedBackendMemberId = dto.CreatedBackendMemberId,
				CreatedTime = dto.CreatedTime
			};

			db.Boards.Add(entity);
			db.SaveChanges();

			return ApiResult.Success("新增成功");
		}

		private string GetUniqueFileName(string fileName)
		{
			var guid = Guid.NewGuid().ToString("N"); // 生成唯一的識別碼
			var extension = Path.GetExtension(fileName); // 取得檔案副檔名
			var uniqueFileName = $"{guid}{extension}"; // 組合新的檔案名稱

			return uniqueFileName;
		}


		//DELETE: api/BoardsApi/5
		[ResponseType(typeof(ApiResult))]
		public ApiResult DeleteBoard(int id)
		{
			Board board = db.Boards.Find(id);

			if (board == null)
			{
				return ApiResult.Fail("找不到這筆資料");
			}
			if (board.GameId != null)
			{
				return ApiResult.Fail("無法刪除遊戲相關版");
			}

			try
			{
				db.Boards.Remove(board);
				db.SaveChanges();
				return ApiResult.Success("完成刪除");
			}
			catch (Exception ex)
			{
				return ApiResult.Fail("無法刪除：" + ex.Message);
			}

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool BoardExists(int id)
		{
			return db.Boards.Any(e => e.Id == id);
		}
		private bool BoardNameExists(string name)
		{
			return db.Boards.Any(e => e.Name == name);
		}
	}

}