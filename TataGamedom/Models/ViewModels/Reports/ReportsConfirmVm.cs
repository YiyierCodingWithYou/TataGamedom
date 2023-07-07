using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.Reports
{
	public class ReportsConfirmVm
	{
		[Required]
		public int Id { get; set; }
		[Required]
        public string ReviewComment { get; set; }
	}
}