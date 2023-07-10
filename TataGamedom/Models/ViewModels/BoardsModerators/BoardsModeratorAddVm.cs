using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.BoardsModerators
{
	public class BoardsModeratorAddVm
	{
		[Required]
		public string MemberAccount { get; set; }
		[Required]
		public string BoardName { get; set; }
	}
}