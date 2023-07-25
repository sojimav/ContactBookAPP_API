using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace ContactBookAPP.Models
{
	public class UserContact :IdentityUser
    {
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string PhotoUrl { get; set; } = string.Empty;
		public DateTime DateOfBirth { get; set; }	
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
