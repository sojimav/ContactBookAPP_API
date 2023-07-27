//using ContactBookAPP.Authentication.Interface;
//using ContactBookAPP.CloudinaryDetails;
//using ContactBookAPP.Context;
//using ContactBookAPP.DTO;
//using ContactBookAPP.Models;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using System.Text;
//using System.Transactions;


//namespace ContactBookAPP.Authentication.Logic
//{
//	public class CrudeImplementation : ICrudeService
//	{
//		private readonly UserManager<Persons> _userManager;
//		private readonly RoleManager<Role> _roleManager;
//		private readonly UserDbContext _userDbContext;

//		public CrudeImplementation(UserManager<Persons> userManager, RoleManager<Role> roleManager, UserDbContext userDbContext)
//		{
//			_userManager = userManager;
//			_roleManager = roleManager;
//			_userDbContext = userDbContext;
//		}

//		//private readonly CloudinaryService _cloudinaryService;




//		public async Task<string> Create(RegisterPersonDTO personDTO)
//		{
//			if (personDTO == null)
//			{
//				throw new NullReferenceException("You did not register!");
//			}

//			if (await _userManager.FindByEmailAsync(personDTO.Email) != null)
//			{
//				throw new Exception("User already exists!");
//			}


//			var person = new Persons()
//			{
//				FirstName = personDTO.FirstName,
//				LastName = personDTO.LastName,
//				Email = personDTO.Email,
//				PhoneNumber = personDTO.PhoneNumber,
//				State = personDTO.State,
//				City = personDTO.City,
//				Address = personDTO.Address,
//				PhotoUrl = personDTO.PhotoUrl,
//				Roles = new List<Role>
//				{
//					new Role
//					{
//						Description = "Regular",
//						CreatedDate = DateTime.UtcNow,
//						IsAssignable = true
//					}
//				}
				
//			};
			  
//			// a transaction ensures that a group of related operations either all succeed or all fail together.
//			// It helps maintain data consistency and integrity.

//				var createUser = await _userManager.CreateAsync(person, personDTO.Password);
				
//					var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(person);
//					var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
//					var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);			

//				return "User registered sucessfully!";
			
			
//		}

//			public async Task<Persons> Read(string Id)
//			{
//				if( await _userManager.FindByIdAsync(Id) == null)
//				{
//					throw new ArgumentNullException("id");
//				}
				
//			    var result = await _userManager.FindByIdAsync(Id);
//		      	return result;
//			}

//			public async Task<List<Persons>> Read(int pageSize = 10, int page = 1)
//			{
//				 if (pageSize <= 0)
//				{
//					throw new ArgumentOutOfRangeException(nameof(pageSize));
//				}
//				  var result = await _userDbContext.Persons.Skip((page  - 1) * pageSize)
//					.Take(pageSize).
//					OrderBy(li => li.Id).ToListAsync();

//		      	return result;
//			 }

//			public async Task<string> Update(RegisterPersonDTO personDTO)
//			{
//				if(personDTO == null)
//				{
//					throw new ArgumentNullException(nameof(personDTO));
//				}

//		        _userDbContext.Entry(personDTO).State = EntityState.Modified;
//			     await _userDbContext.SaveChangesAsync();

//			       return "Entity Updated Sucessfully!";
//			}



//		    public async Task<string> Delete(string id)
//			{
//				if(_userManager.FindByIdAsync(id) == null)
//			{
//				throw new ArgumentNullException(nameof(id));
//			}
//				var result = await _userManager.FindByIdAsync(id);

//			   if(result != null)  
//				await  _userManager.DeleteAsync(result);
//		    	return "Entity sucessfully deleted!";
//			}


			
//	}
//}
