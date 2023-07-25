using ContactBookAPP.Context;
using Microsoft.EntityFrameworkCore;

namespace ContactBookAPP.Extension
{
	public static class ConfigureServices
	{
		public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<UserDbContext>(options => options
			.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
		}
	}
}
