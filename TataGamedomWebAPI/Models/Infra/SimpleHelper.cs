using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Models.Infra
{

	public class SimpleHelper
	{
		private readonly AppDbContext _context;

		public SimpleHelper(AppDbContext context)
		{
			_context = context;
		}

		public int FindBackendmemberIdByAccount(string account)
		{
			var backendMember = _context.BackendMembers.FirstOrDefault(x => x.Account == account);
			int id = backendMember?.Id ?? 0;
			return id;
		}

		public int memberIdByAccount(string account)
		{
			try
			{
			var member =  _context.Members.FirstOrDefault(x => x.Account == account);
			int id = member?.Id ?? 0;
			return id;
			}catch(Exception ex)
			{
				return 0;
			}
		}

		public int boardIdByName(string name)
		{
			var board = _context.Boards.FirstOrDefault(x => x.Name == name);
			int id = board?.Id ?? 0;
			return id;
		}

		public bool IsBoadMod (int boardId, int memberId)
		{
			var result = _context.BoardsModerators.Any(m => m.BoardId== boardId&& m.ModeratorMemberId==memberId);
			return result;
		}

		public (bool IsVoted,int? voteId) IsPostVoted (int postId, int memberId)
		{
			var result = _context.PostUpDownVotes.FirstOrDefault(v => v.PostId == postId && v.MemberId == memberId);
			var voteId = (result!=null) ? result.Id : (int?)null;
			return (result!=null,voteId);
		}

		public (bool IsVoted, int? voteId) IsCommentVoted(int commentId, int memberId)
		{
			var result = _context.PostCommentUpDownVotes.FirstOrDefault(v => v.PostCommentId == commentId && v.MemberId == memberId);
			var voteId = (result != null) ? result.Id : (int?)null;
			return (result != null, voteId);
		}
	}
}
