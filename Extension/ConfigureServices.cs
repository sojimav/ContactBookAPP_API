using ContactBookAPP.CloudinaryDetails;
using ContactBookAPP.Context;
using ContactBookAPP.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

			services.AddIdentity<Persons, Role>()
				.AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();


			// Configure JWT authentication
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("YourJwtSecretKey")),
				ValidateIssuer = false,
				ValidateAudience = false
			};
		});
		}


	}
}
