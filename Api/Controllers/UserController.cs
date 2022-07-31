using DAL.Dtos.Resquests;
using DAL.Dtos.Responses;
using DAL.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Authorization;
using DAL.Dtos.Auth;
using BCrypt.Net;
using DAL.Entities.Candidates;
using Api.Identity;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private CandidatRepository _userRepo;
        private AppDbContext _context;

        private IAuthenticationService _authenticationService;

        public UserController(CandidatRepository userRepo, AppDbContext context, IAuthenticationService authenticationService)
        {
            _userRepo = userRepo;
            _context = context;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate(LoginDto model)
        {
            var response = _userRepo.Authenticate(model);
            return Ok(response);
        }
        //Get current use
        /*[Route("/current")]
        public async Task<IEnumerable<User>> getCurrent()
        {
            AuthorizationFilterContext context;
            var user = (User)context.HttpContext.Items["User"];
            return Ok(user);
        }*/
        //Get All
        [Route("")]
        [HttpGet]
        [Authorize(Role.Employer)]
        public async Task<IEnumerable<User>> getAll()
        {
            try
            {
                return _userRepo.GetAll().ToList();


            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        [Route("Register/Candidat")]
        [HttpPost]
        public async Task<User> addUser([FromBody] CandidatRegisterDto user)
        {
            var _user = new User();
            _user.Firstname = user.firstname;
            _user.Lastname = user.lastname;
            _user.PhoneNumber = user.phone_number;
            _user.Email = user.email;
            _user.DateOfBirth = Convert.ToDateTime(user.birthdate);
            _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.password);
            _user.Role = Role.Candidat;
            _userRepo.Add(_user);
            _context.SaveChanges();
            return _user;
        }
        [Route("Register/Employer")]
        [HttpPost]
        public async Task<User> addUser([FromBody] EmployerRegisterDto user)
        {
            var _user = new User();
            _user.Firstname = user.firstname;
            _user.Lastname = user.lastname;
            _user.Role = Role.Employer;
            _user.Email = user.email;
            _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.password);
            _user.DateOfBirth = Convert.ToDateTime(user.birthdate);
            _userRepo.Add(_user);
            _context.SaveChanges();
            return _user;
        }




        [Route("getOne")]
        [HttpGet]
        //get by id 
        public async Task<User> GetUser(string id)
        {
            var user = _userRepo.GetAll().FirstOrDefault(x => x.UserId == id);

            return user;
        }

        [HttpDelete]
        public void DeleteUser(string id)
        {
            _userRepo.Delete(_userRepo.GetAll().FirstOrDefault(x => x.UserId == id));
            _context.SaveChanges();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] userRegistration userRegistration)
        {

            var userResult = await _authenticationService.RegisterUserAsync(userRegistration);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }
    }
}
