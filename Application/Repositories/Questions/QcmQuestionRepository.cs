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
    public class QcmQuestionRepository : GenericRepository<QcmQuestion> , IQcmQuestionRepository
    {
        AppDbContext _context;

        public QcmQuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
