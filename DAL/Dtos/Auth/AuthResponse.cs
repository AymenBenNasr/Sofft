using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Auth
{
    public class AuthResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }

        public AuthResponse(User user, string token)
        {
            Id = user.UserId;
            FirstName = user.Firstname;
            LastName = user.Lastname;
            Email = user.Email;
            Token = token;
        }
    }
}
