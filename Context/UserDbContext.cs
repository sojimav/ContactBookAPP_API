using ContactBookAPP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactBookAPP.Context
{
	public class UserDbContext : IdentityDbContext<UserContact>
	{
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
       
    }
}
