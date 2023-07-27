using System.ComponentModel.DataAnnotations;

namespace ContactBookAPP.DTO
{
	public class RegisterPersonDTO
	{
		[Required]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		public string LastName { get; set; } = string.Empty;

		[Required]
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;

		[Required]
		public string Password { get; set; } = string.Empty;	
		public string Address { get; set; } = string.Empty;
		public string PhotoUrl { get; set; } = string.Empty;
		public string State { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		

	}
}
