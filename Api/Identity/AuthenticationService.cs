using System;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Identity
{
	public class AuthenticationService : IAuthenticationService
	{
        private readonly UserManager<User> _userManager;
        public AuthenticationService(
        UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(userRegistration model)
        {
            var user = new User
            {
                Firstname = model.FirstName,
                Lastname = model.LasttName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }
    }
}

