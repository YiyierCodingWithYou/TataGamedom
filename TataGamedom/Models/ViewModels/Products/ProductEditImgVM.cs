using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.Products
{
	public class ProductEditImgVM
	{
        public int ProductId { get; set; }
        public List<int> Id { get; set; }

		[Display(Name = "商品圖片")]
		public List<string> Image { get; set; }
		[Display(Name = "最後修改時間")]		
		public DateTime ModifiedTime { get; set; }
		[Display(Name = "最後修改者")]
		public int ModifiedTimeBackendMemberId { get; set; }

		public ProductEditImgVM()
		{
			// 初始化 Image 属性为一个空的列表
			Image = new List<string>();
		}
	}
}