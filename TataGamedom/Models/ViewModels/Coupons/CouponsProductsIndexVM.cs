using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.Coupons
{
	public class CouponsProductsIndexVM
	{
		[Display(Name = "商品編號")]
		public string Index { get; set; }
		[Display(Name = "商品名稱")]

		public string Name { get; set; }
		[Display(Name = "平台")]
		public string Platform { get; set; }
		[Display(Name = "活動名稱")]
		public string CouponName { get; set; }
		[Display(Name = "活動門檻")]
		public int Threshold { get; set; }
		[Display(Name = "活動敘述")]
		public string Description { get; set; }
		[Display(Name = "售價")]

		public int Price { get; set; }
		[Display(Name = "特價")]
		public int SpecialPrice { get; set; }
		[Display(Name = "若達門檻")]
		public int IfReach { get; set; }
    }
}