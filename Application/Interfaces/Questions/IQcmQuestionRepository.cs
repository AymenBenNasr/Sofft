using DAL.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Questions
{
    public interface IQcmQuestionRepository : IGenericRepository<QcmQuestion>
    {
    }
}
