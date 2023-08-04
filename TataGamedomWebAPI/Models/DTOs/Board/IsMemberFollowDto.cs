namespace TataGamedomWebAPI.Models.DTOs.Board
{
	public class IsMemberFollowDto
	{
		public bool isFollow { get; set; }
		public bool isFavorite { get; set; }

        public IsMemberFollowDto(bool isFollow, bool isFavorite)
        {
            this.isFollow = isFollow;
            this.isFavorite = isFavorite;
        }

    }
}
