using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Infra.DapperRepositories;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.Services;
using TataGamedom.Models.ViewModels.Games;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data.Entity;
using System.Data;
using System.IO;
using System.Linq;

namespace TataGamedom.Controllers
{
	public class GamesController : Controller
	{
		private AppDbContext db = new AppDbContext();
		[Authorize]
		public ActionResult Index()
		{
			IEnumerable<GameIndexVM> games = GetGames();
			return View(games);
		}

		private IEnumerable<GameIndexVM> GetGames()
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.Search();
		}
		[Authorize]
		public ActionResult Create()
		{
			var gameClassifications = GetGameClassifications();
			GameCreateVM model = new GameCreateVM
			{
				GameClassification = gameClassifications
			};
			return View(model);
		}

		private List<GameClassificationsCode> GetGameClassifications()
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.GetGameClassifications();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(GameCreateVM vm, HttpPostedFileBase GameCoverImg)
		{
			var currentUserAccount = User.Identity.Name;
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
			var savedFileName = SaveFile(GameCoverImg);

			vm.GameCoverImg = savedFileName;
			vm.CreatedBackendMemberId = memberInDb.Id;

			if (ModelState.IsValid == false)
			{
				vm.GameClassification = GetGameClassifications();
				return View(vm);
			}
			Result createResult = CreateGame(vm);
			if (createResult.IsSuccess)
			{
				CreateGameClassification(vm);
				CreateGameBoard(vm);
				return RedirectToAction("Index");
			}
			ModelState.AddModelError(string.Empty, createResult.ErrorMessage);
			vm.GameClassification = GetGameClassifications();
			return View(vm);
		}

		private void CreateGameBoard(GameCreateVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.CreateBoard(vm);
		}

		private void CreateGameClassification(GameCreateVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.CreateClassification(vm);
		}

		private Result CreateGame(GameCreateVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.CreateGame(vm);
		}

		private string SaveFile(HttpPostedFileBase file1)
		{
			var path = Server.MapPath("~/Files/Uploads");

			var helper = new UploadFileHelper(new GuidRenameProvider(),
											new RequiredValidator(), // 必需上傳檔案
											new ImageValidator(), // 必需是圖片檔案
											new FileSizeValidator(1920 * 1920) // 必需小於1MB		
											);
			var fileName = helper.SaveFile(file1, path);

			return fileName ?? string.Empty;
		}
		[Authorize]
		public ActionResult Edit(int id)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			var gameEditVM = service.GetGameEditVM(id);
			return View(gameEditVM);
		}

		[HttpPost]
		public ActionResult Edit(GameEditVM vm)
		{
			if (ModelState.IsValid)
			{
				var currentUserAccount = User.Identity.Name;
				var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);

				vm.ModifiedBackendMemberId = memberInDb.Id;
				Result editResult = UpdateGames(vm);
				if (editResult.IsSuccess)
				{
					UpdateGameClassification(vm);
					CreateGameClassification(vm);
					return RedirectToAction("Index");
				}
				ModelState.AddModelError(string.Empty, editResult.ErrorMessage);
				vm.GameClassification = GetGameClassifications();
				return View(vm);
			}
			vm.GameClassification = GetGameClassifications();
			return View(vm);
		}
		private void CreateGameClassification(GameEditVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.CreateClassification(vm);
		}
		private void UpdateGameClassification(GameEditVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			service.UpdateClassification(vm);
		}

		private Result UpdateGames(GameEditVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.UpdateGame(vm);
		}
		[Authorize]
		public ActionResult EditGameCover(int id)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			var gameCover = service.GetGameCover(id);
			return View(gameCover);
		}

		[HttpPost]
		public ActionResult EditGameCover(GameEditCoverImgVM vm, HttpPostedFileBase file1)
		{
			if (file1 != null) // 檢查是否選擇了新的檔案
			{
				var savedFileName = SaveFile(file1);

				vm.GameCoverImg = savedFileName;
			}
			if (ModelState.IsValid)
			{
				var currentUserAccount = User.Identity.Name;
				var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
				vm.ModifiedBackendMemberId = memberInDb.Id;
				IGameRepository repo = new GameDapperRepository();
				GameService service = new GameService(repo);
				service.EditGameCover(vm);
				return RedirectToAction("Index");
			}
			return View(vm);
		}
		[Authorize]
		public ActionResult AddProduct(int id)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			var product = service.AddProduct(id);
			var platforms = db.GamePlatformsCodes.Where(code => !code.Products.Any(p => p.GameId == id));
			ViewBag.Platform = new SelectList(platforms, "Id", "Name");
			ViewBag.PlatformOptionsCount = platforms.Count();

			return View(product);
		}
		[HttpPost]
		public ActionResult AddProduct(GameAddProductVM vm, HttpPostedFileBase[] files)
		{
			var currentUserAccount = User.Identity.Name;
			var memberInDb = db.BackendMembers.FirstOrDefault(m => m.Account == currentUserAccount);
			vm.CreateBackendMemberId = memberInDb.Id;

			if (files != null && files.Length > 0)
			{
				List<string> savedFileNames = new List<string>();

				foreach (var file in files)
				{
					var savedFileName = SaveFile(file);
					if (savedFileName != null)
					{
						savedFileNames.Add(savedFileName);
					}
				}
				vm.ProductImg = savedFileNames;
			}
			if (!ModelState.IsValid)
			{
				IGameRepository repo = new GameDapperRepository();
				GameService service = new GameService(repo);
				ViewBag.Platform = new SelectList(db.GamePlatformsCodes.Where(code => !code.Products.Any(p => p.GameId == vm.Id)), "Id", "Name");
				return View(vm);
			}
			var productResult = CreateProduct(vm);
			if (productResult.IsFail)
			{
				ModelState.AddModelError(string.Empty, productResult.ErrorMessage);
				ViewBag.Platform = new SelectList(db.GamePlatformsCodes, "Id", "Name");
				return View(vm);
			}
			var imgResult = CreateProductImg(vm);
			if (imgResult.IsFail)
			{
				ModelState.AddModelError(string.Empty, imgResult.ErrorMessage);
				return View(vm);
			}
			return RedirectToAction("Index");
		}

		private Result CreateProductImg(GameAddProductVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.CreateProductImg(vm);
		}

		private Result CreateProduct(GameAddProductVM vm)
		{
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			return service.CreateProduct(vm);
		}
		[Authorize]
		public ActionResult Upload()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Upload(HttpPostedFileBase file)
		{
			if (!ModelState.IsValid) { return View(); }
			if (file == null)
			{
				return View();
			}
			var currentUserAccount = User.Identity.Name;
			IGameRepository repo = new GameDapperRepository();
			GameService service = new GameService(repo);
			var upload = service.Upload(file, currentUserAccount);
			if (upload.IsFail)
			{
				ViewBag.Message = upload.ErrorMessage;
				return View();
			}
			ViewBag.Message = "匯入成功";
			return View();
		}
	}
}