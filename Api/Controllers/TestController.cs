using Application.Interface.TestInterface;
using Application.Repositories.TestRepo;
using DAL.Entities.Test;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        ITestRepository _testRepo;
        AppDbContext _context;

        public TestController(ITestRepository questRepo, AppDbContext context)
        {
            this._testRepo = questRepo;
            _context = context;
        }
        //Questions
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Test>> getAllTests()
        {
            try
            {
                return _context.Tests.FromSqlRaw($"TestsList").ToList();


            }
            catch (Exception ex)
            {
                return new List<Test>();
            }
        }
 

    }
}
