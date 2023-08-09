using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Infrastructure
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
                var member = _context.Members.FirstOrDefault(x => x.Account == account);
                int id = member?.Id ?? 0;
                return id;
            }
            catch (Exception ex)
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

        public bool IsBoardMod(int boardId, int memberId)
        {
            var result = _context.BoardsModerators.Any(m => m.BoardId == boardId && m.ModeratorMemberId == memberId);
            return result;
        }

        public (bool IsVoted, int? voteId, string? voteType) IsPostVoted(int postId, int memberId)
        {
            var result = _context.PostUpDownVotes.FirstOrDefault(v => v.PostId == postId && v.MemberId == memberId);
            var voteId = result != null ? result.Id : (int?)null;
            string? voteType = null;
			if (result != null)
            {
             voteType = (result.Type) ? "Up" : "Down";
            }
			return (result != null, voteId, voteType);
        }

        public (bool IsVoted, int? voteId, string? voteType) IsCommentVoted(int commentId, int memberId)
        {
            var result = _context.PostCommentUpDownVotes.FirstOrDefault(v => v.PostCommentId == commentId && v.MemberId == memberId);
            var voteId = result != null ? result.Id : (int?)null;
			string? voteType = null;
			if (result != null)
			{
				voteType = (result.Type) ? "Up" : "Down";
			}
			return (result != null, voteId, voteType);
		}

        public bool PostIsAuthor(int postId, int memberId) {
			var result = _context.Posts.FirstOrDefault(p => p.Id == postId && p.MemberId == memberId);
            return result != null;
		}

		public bool CommentIsAuthor (int commentId, int memberId)
		{
			var result = _context.PostComments.FirstOrDefault(c => c.Id == commentId && c.MemberId == memberId);
			return result != null;
		}


		public bool PostIsMod(int postId, int memberId)
        {
			var boardId = _context.Posts.FirstOrDefault(p => p.Id == postId)?.BoardId;
            return IsBoardMod(boardId ?? 0, memberId);
		}   

	}


}
