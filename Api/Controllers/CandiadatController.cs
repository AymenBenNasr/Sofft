using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Application.Authorization;
using DAL.Entities;
using DAL.Dtos.Auth;
using DAL.Entities.Candidates;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandiadatController : ControllerBase
    {
        private CandidatRepository _userRepo;
        private AppDbContext _context;

        public CandiadatController(CandidatRepository userRepo, AppDbContext context)
        {
            _userRepo = userRepo;
            _context = context;
        }

        [Authorize(roles: Role.Candidat )]
        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<User>> getCandidats()
        {
            try
            {
                return _context.Users.Where(u => u.Role == Role.Candidat).ToList();
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        [Route("Register")]
        [HttpPost]
        public async Task<User> addUser([FromBody] CandidatRegisterDto user)
        {
            var _user = new Candidat();
            _user.Firstname = user.firstname;
            _user.Lastname = user.lastname;
            _user.PhoneNumber = user.phone_number;
            _user.Email = user.email;
            _user.DateOfBirth = Convert.ToDateTime(user.birthdate);
            _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.password);
            _user.experiences = user.experiences;
            _user.Role = Role.Candidat;
            _userRepo.Add(_user);
            _context.SaveChanges();
            return _user;
        }



    }
}
