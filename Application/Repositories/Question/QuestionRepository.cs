using Application.Interfaces.Questions;
using DAL.Entities.Questions;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Questions
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        AppDbContext _context;
        public QuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        
    
    
    }
}
