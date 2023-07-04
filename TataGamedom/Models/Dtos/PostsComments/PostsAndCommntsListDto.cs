using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.Dtos.PostsComments
{
	public class PostsAndCommentsListDto
	{
		public string Type { get; set; }
		public int ID { get; set; }
		public int? RespondedPost { get; set; }
		public int? RespondedComment { get; set; }
		public string MemberId { get; set; }
		public string MemberName { get; set; }
		public string Content { get; set; }
		public DateTime DateTime { get; set; }
		public int LikesCount { get; set; }
		public int UnlikesCount { get; set; }
		public int CommentsCount { get; set; }

	}
}