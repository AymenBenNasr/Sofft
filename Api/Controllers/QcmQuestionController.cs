using Application.Interfaces.Questions;
using DAL.Entities.Questions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QcmQuestionController : ControllerBase
    {
        IQcmQuestionRepository _qcmRepo;
        AppDbContext _context;

        public QcmQuestionController(IQcmQuestionRepository qcmRepo, AppDbContext context)
        {
            _qcmRepo = qcmRepo;
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<QcmQuestion>> getAll()
        {
            try
            {
                return _qcmRepo.GetAll().ToList();


            }
            catch (Exception ex)
            {
                return new List<QcmQuestion>();
            }
        }

        [Route("add")]

        [HttpPost]
        public async Task<QcmQuestion> addQuestion([FromBody] QcmQuestion question)
        {
            var _question = new QcmQuestion();
            _question.description = question.description;
            _question.title = question.title;
            _question.duration = question.duration;
            _question.difficulty = question.difficulty;
            _question.score = question.score;
            _question.priority = question.priority;
            _question.responses = question.responses;
            _qcmRepo.Add(_question);
            _context.SaveChanges();
            return _question;
        }



    }
}
