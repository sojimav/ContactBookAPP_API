using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactBookAPP.DTO;
using Microsoft.AspNetCore.Identity;
using ContactBookAPP.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ContactBookAPP.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public partial class AccountController : ControllerBase
	{
		private readonly UserManager<Persons> _userManager;
		private readonly SignInManager<Persons> _signInManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly IConfiguration _configuration;

		public AccountController(UserManager<Persons> userManager, 
			SignInManager<Persons> signInManager, 
			RoleManager<Role> roleManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterPersonDTO model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// Check if the user already exists
			var existingUser = await _userManager.FindByEmailAsync(model.Email);
			if (existingUser != null)
			{
				return BadRequest("User already exists.");
			}

			// Create the user
			var newUser = new Persons()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				UserName = model.Username,
				Address = model.Address,
				State = model.State,
				City	= model.City,

			};
			var result = await _userManager.CreateAsync(newUser, model.Password);

			if (result.Succeeded)
			{
				 
				// Assign the user to the "Regular" role
				if (!await _roleManager.RoleExistsAsync("Regular"))
				{
				var roles =	await _roleManager.CreateAsync(new Role
					{   
						Id = Guid.NewGuid().ToString(),
						Name = "Regular",
						Description = "Regular User",
						CreatedDate = DateTime.Now,
						IsAssignable = true
					});

					await _userManager.AddToRoleAsync(newUser, "Regular");
				}

				var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
				var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
				var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);
				

				return Ok("Registration successful");
			}
			else
			{
				return BadRequest(result.Errors);
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] Login model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user == null)
			{
				return NotFound(new { Message = "Invalid credentials." });
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);

			if (!result.Succeeded)
			{
				return Unauthorized(new { Message = "Invalid credentials." });
			}

			var token = GenerateJwtToken(user);

			return Ok(new { Token = token });
		}




		private string GenerateJwtToken(Persons user)
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			// Set a default expiration in minutes if "AccessTokenExpiration" is missing or not a valid numeric value.
			if (!double.TryParse(jwtSettings["AccessTokenExpiration"], out double accessTokenExpirationMinutes))
			{
				accessTokenExpirationMinutes = 30; // Default expiration of 30 minutes.
			}

			var token = new JwtSecurityToken(
				issuer: null,
				audience: null,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(accessTokenExpirationMinutes),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
