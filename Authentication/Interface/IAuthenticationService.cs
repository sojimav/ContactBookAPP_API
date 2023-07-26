using ContactBookAPP.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookAPP.Authentication.Interface
{
	public interface IAuthenticationService
	{
		Task<string> Create(RegisterPersonDTO personDTO);
		RegisterPersonDTO Read();
		void Update(RegisterPersonDTO personDTO);
		Task<string> Delete(string email);
	}
}
