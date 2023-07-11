using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using TataGamedom.Models.Infra;
using TataGamedom.Models.Interfaces;
using TataGamedom.Models.ViewModels.Coupons;

namespace TataGamedom.Models.Services
{
	public class CouponService
	{
		private ICouponRepository _repo;
        public CouponService(ICouponRepository repo)
        {
            _repo=repo;
        }

        public IEnumerable<CouponIndexVM> Get()
        {
            return _repo.Get();
        }

        public Result Create(CouponCreateVM vm)
        {
			var selectedStartDate = vm.StartTime;//.Date();
			var selectedEndDate = vm.EndTime.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
			bool status =false;
            if(DateTime.Now>= selectedStartDate && DateTime.Now<= selectedEndDate)
            {
                status = true;
            }

            var create = new CouponCreateVM
            {
                Name = vm.Name,
                Discount = vm.Discount,
                DiscountTypeId = vm.DiscountTypeId,
                Description = vm.Description,
                Threshold = vm.Threshold,
                StartTime = selectedStartDate,
                EndTime = selectedEndDate,
                ActiveFlag = status,
                CreatedBackendMemberId = vm.CreatedBackendMemberId,
                CreatedTime = DateTime.Now,
            };
            var createResult = _repo.Create(create);
            if (!createResult)
            {
                return Result.Fail("優惠券新增失敗");
            }
            return Result.Success();
        }
    }
}