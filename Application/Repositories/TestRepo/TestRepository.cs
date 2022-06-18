using Application.Interface.TestInterface;
using DAL.Entities.Test;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.TestRepo
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        AppDbContext _context;
        public TestRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
