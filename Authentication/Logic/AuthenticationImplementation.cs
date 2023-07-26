using ContactBookAPP.Authentication.Interface;
using ContactBookAPP.CloudinaryDetails;
using ContactBookAPP.DTO;
using ContactBookAPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Web.Mvc;

namespace ContactBookAPP.Authentication.Logic
{
	public class AuthenticationImplementation : IAuthenticationService
	{
		private readonly UserManager<Persons> _userManager;
		private readonly UserManager<Role> _roleManager;
		private readonly CloudinaryService _cloudinaryService;

		public AuthenticationImplementation(UserManager<Persons> userManager, 
			UserManager<Role> roleManager,
			CloudinaryService cloudinaryService)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_cloudinaryService = cloudinaryService;
		}

		public async Task<IActionResult> CreateNewContact(RegisterPersonDTO personDTO)
		{
			if(ModelState.IsValid)
			return Ok();
		}

		public void Delete(RegisterPersonDTO personDTO)
		{
			throw new NotImplementedException();
		}

		public RegisterPersonDTO ReadExistingContacts()
		{
			throw new NotImplementedException();
		}

		public void Update(RegisterPersonDTO personDTO)
		{
			throw new NotImplementedException();
		}
	}
}
