using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.PostsComments
{
	public class PostsCommentsListVm
	{
		public int BoardId { get; set; }
		public string BoardName { get; set; }
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
		public bool ActiveFlag { get; set; }
		public DateTime DeleteDateTime { get; set; }
		public int DeleteBackendMemberId { get; set; }
		public int DeleteMemberName { get; set; }

	}
}