namespace TataGamedomWebAPI.Models.DTOs.Board
{
	public class MemberFollowBoardListDto
	{
		public int Id { get; set; }
		public int BoardId { get; set; }
		public string BoardName { get; set; }
		public bool IsFavorite { get; set; }
	}
}
