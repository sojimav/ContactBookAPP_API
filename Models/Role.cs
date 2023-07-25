using Microsoft.AspNetCore.Identity;

namespace ContactBookAPP.Models
{
	public class Role : IdentityRole<string>
	{
		public string Description { get; set; } // Role description
		public DateTime CreatedDate { get; set; } // Date the role was created
		public bool IsAssignable { get; set; }
	}
}
