namespace TataGamedomWebAPI.Models.DTOs.Board
{
	public class MemberAboutDto
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string? AboutMe { get; set; }
		public string? IconURL { get; set; }
		public bool IsFollowing { get; set; } =false;
		public bool IsFollowingYou { get; set; }=false;
		public int FollowerCounting { get; set; }
		public int FollowingCounting { get; set; }
		public List<FollowerDto>? Followers { get; set; }
		public List<FollowerDto>? Followings { get; set; }
    }
	public class FollowerDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? AboutMe { get; set; }
		public string? IconURL { get; set; }
		public bool IsFollowing { get; set; } = false;
		public bool IsFollowingYou { get; set; } = false;
	}
}
