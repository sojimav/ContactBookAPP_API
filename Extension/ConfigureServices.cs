using ContactBookAPP.CloudinaryDetails;
using ContactBookAPP.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContactBookAPP.Extension
{
    public static class ConfigureServices
	{
		public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<UserDbContext>(options => options
			.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
			services.AddScoped<CloudinaryService>();
		}
	}
}
