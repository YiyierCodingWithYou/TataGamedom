namespace TataGamedomWebAPI.Models.DTOs.Members
{
	public class ChangePasswordDTO
	{
		public string Account { get; set; } = null!;
		public string OringinalPassword { get; set; } = null!;
		public string CreatePassword { get; set; } = null!;
		public string ConfirmPassword { get; set; } = null!;
	}
}
