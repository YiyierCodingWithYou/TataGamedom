using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TataGamedom.Models.EFModels;

namespace TataGamedom.Models.ViewModels.Coupons
{
	public class EditCouponProductsVM
	{
		public int Id { get; set; }
		[Display(Name = "活動名稱")]
		public string CouponName { get; set; }
		[Display(Name = "活動內容")]

		public string Description { get; set; }
		public List<Product> Products { get; set; }
		[Display(Name = "活動商品")]
		public List<int> SelectedProductIds { get; set; }
		[Display(Name = "商品列表")]
		public List<Product> AvailableProducts { get; set; }

        public DateTime EndTime { get; set; }
        public EditCouponProductsVM()
		{
			SelectedProductIds = new List<int>();
			AvailableProducts = new List<Product>();
		}
	}
}