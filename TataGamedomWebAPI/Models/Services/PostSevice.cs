using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.DTOs.Post;

namespace TataGamedomWebAPI.Models.Services
{
    public class PostSevice
	{
		private readonly AppDbContext _context;

		public PostSevice(AppDbContext context)
		{
			_context = context;
		}

		public IEnumerable<PostReadDto> GetPosts(string? keyword, int? postId, string? MemberAccount, string? BoardName, int page = 1)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<CommentReadDto> GetPostsComments(int postId)
		{
			throw new NotImplementedException();
		}
	}
}
