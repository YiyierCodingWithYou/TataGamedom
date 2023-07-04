using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TataGamedom.Models.EFModels;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.ViewModels.Products;

namespace TataGamedom.Models.Services
{
	public class ProductService
	{
		private AppDbContext db = new AppDbContext();

		private IProductRepository _repo;
		public ProductService(IProductRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<ProductIndexVM> Get()
		{
			return _repo.Get();
		}
		public ProductEditVM Get(int id)
		{

			var product = _repo.GetGameById(id);
			if (product == null) { return null; }
			return product;
		}

		public Result Edit(ProductEditVM vm)
		{
			//抓修改前的資料
			var productOriginal = _repo.GetGameById(vm.Id);
			//抓是否有VM欲修改成的資料
			var product = _repo.GetGameByGameIdAndGPId(vm);
			if (product != null && productOriginal.GamePlatform != product.GamePlatformId)
			{
				return Result.Fail("該遊戲已存在此平台商品！"); //已經從controller擋掉該遊戲已存在的其他平台，基本上不會進這條
			}
			else
			{
				string index = "";
				switch (vm.GamePlatform)
				{
					case 1:
						index = "PC";
						break;
					case 2:
						index = "PS";
						break;
					case 3:
						index = "SW";
						break;
				}
				var update = new ProductEditVM
				{
					Id = vm.Id,
					Index = (index + vm.GameId.ToString() + vm.GamePlatform.ToString()),
					GamePlatform = vm.GamePlatform,
					IsVirtual = vm.IsVirtual,
					Price = vm.Price,
					ProductStatus = vm.ProductStatus,
					SystemRequire = vm.SystemRequire,
					SaleDate = vm.SaleDate,
					ModifiedBackendMemberId = vm.ModifiedBackendMemberId,
					ModifiedTime = DateTime.Now
				};
				var updateResult = _repo.Update(update);
				if (!updateResult)
				{
					return Result.Fail("商品編輯失敗！");
				}
			}
			return Result.Success();
		}

		public List<ProductEditImgVM> GetImgs(int id)
		{
			var result = _repo.GetImgs(id);
			return result;
		}
	}
}