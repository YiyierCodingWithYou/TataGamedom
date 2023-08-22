namespace TataGamedomWebAPI.Models.DTOs.Members
{
    public class MembersDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Account { get; set; } = null!;

		//public string Password { get; set; } = null!;

		public DateTime Birthday { get; set; }

		public int Age { get; set; }

		public string Email { get; set; } = null!;

		public string Phone { get; set; } = null!;

		public DateTime RegistrationDate { get; set; }

		public string? IconImg { get; set; }

		public bool IsConfirmed { get; set; }

		public string? ConfirmCode { get; set; }

		public bool ActiveFlag { get; set; }

		public DateTime? LastOnlineTime { get; set; }
	}
}
