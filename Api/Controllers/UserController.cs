using DAL.Dtos.Resquests;
using DAL.Dtos.Responses;
using DAL.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Authorization;
using DAL.Dtos.Auth;
using BCrypt.Net;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepo;
        private AppDbContext _context;

        public UserController(IUserRepository userRepo , AppDbContext context)
        {
            _userRepo = userRepo;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public IActionResult Authenticate(LoginDto model)
        {
            var response = _userRepo.Authenticate(model);
            return Ok(response);
        }

        //Get All
        [Route("")]
        [HttpGet]
        [Authorize(Role.Admin)]
        public async Task<IEnumerable<User>> getAll()
        {
            try
            {
                return  _userRepo.GetAll().ToList();


            }catch (Exception ex)
            {
                return new List<User>();    
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<User> addUser([FromBody] UserDtoRequest user)
        {
            var _user = new User();
            _user.Firstname = user.Firstname;
            _user.Lastname = user.Lastname;
            _user.Role = user.Role;
            _user.Email = user.Email;
            _user.Country = user.Country;
            _user.passwordHash = BCrypt.Net.BCrypt.HashPassword(user.password);
            _user.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
            _userRepo.Add(_user);
            _context.SaveChanges();
            return _user;
        }

        
        

        [Route("getOne")]
        [HttpGet]
        //get by id 
        public async Task<User> GetUser(Guid id)
        {
            var user = _userRepo.GetAll().FirstOrDefault(x => x.Id == id);
            
            return user;
        }

        [HttpDelete]
        public void DeleteUser(Guid id)
        {
            _userRepo.Delete(_userRepo.GetAll().FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }
    }
}
