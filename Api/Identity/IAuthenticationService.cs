using System;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Identity
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUserAsync(userRegistration userForRegistration);

	}
}

