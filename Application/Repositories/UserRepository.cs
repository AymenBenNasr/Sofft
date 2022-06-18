using DAL.Entities;
using Infrastructure.Data;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Authorization;
using Api.Helpers;
using Microsoft.Extensions.Options;
using DAL.Dtos.Auth;
using BCrypt.Net;


namespace Application.Repositories
{
    public class UserRepository : GenericRepository<User>, Interfaces.CandidatRepository
    {
        private AppDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        public UserRepository(AppDbContext context , IJwtUtils jwtUtils , IOptions<AppSettings> appSettings ) : base(context)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value; 
        }
        public AuthResponse Authenticate(LoginDto model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthResponse(user, jwtToken);
        }
        public IEnumerable<User> GetOldUsers(int count)
        {
            return _context.Users.OrderByDescending(u => u.Firstname).ToList();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   }
    }
}
