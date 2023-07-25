using Microsoft.AspNetCore.Identity;

namespace ContactBookAPP.Models
{
	public class Role : IdentityRole<string>
	{
		//public int Id { get; set; }
		public string Name { get; set; }
	}
}
