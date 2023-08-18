namespace TataGamedomWebAPI.Models.DTOs.Members
{
	public class ResetPasswordDTO
	{
		public int MemberId { get; set; }
		public string ConfirmCode { get; set; }
		public string CreatePassword { get; set; }

		public string ConfirmPassword { get; set; }
	}
}
