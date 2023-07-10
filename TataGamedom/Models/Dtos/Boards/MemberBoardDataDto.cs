using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.Dtos.Boards
{
	public class MemberBoardDataDto
	{
		public int MemberThisBoardLikes { get; set; }
		public int MemberThisBoardUnlikes { get; set; }
		public int MemberThisBoardPostsCount { get; set; }
		public int MemberAllBoardLikes { get; set; }
		public int MemberAllBoardUnlikes { get; set; }
		public int MemberAllBoardPostsCount { get; set; }
	}
}