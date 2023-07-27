using ContactBookAPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactBookAPP.Context
{
	public class UserDbContext : IdentityDbContext<Persons, Role, string>
	{
		public DbSet<Role> Roles { get; set; }
		public DbSet<Persons> Persons { get; set; }

		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Persons>()
				.HasMany(u => u.Roles)
				.WithMany()
				.UsingEntity<IdentityUserRole<int>>(
				 ur => ur.HasOne<Role>().WithMany(),
				ur => ur.HasOne<Persons>().WithMany()
				);
				
		}
	}
}
