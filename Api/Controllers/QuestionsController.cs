using Application.Authorization;
using Application.Interfaces.Questions;
using Application.Repositories.Questions;
using DAL.Dtos;
using DAL.Entities;
using DAL.Entities.Questions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionRepository _questRepo;
        AppDbContext _context;

        public QuestionsController(IQuestionRepository questRepo, AppDbContext context)
        {
            this._questRepo = questRepo;
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Question>> getAll()
        {
            try
            {
                return _questRepo.GetAll().ToList();


            }
            catch (Exception ex)
            {
                return new List<Question>();
            }
        }

        [HttpPost]
        [Route("add")]
        [HttpPost]
        public async Task<Question> addQuestion([FromBody] QuestionDto question)
        {
            var _question = new Question();
            _question.description = question.description;
            _question.title = question.title;
            _question.duration = question.duration;
            _question.difficulty = question.difficulty;
            _question.score = question.score;
            _question.domain_id = question.domain_id;
            _questRepo.Add(_question);
            _context.SaveChanges();
            return _question;
        }
        [HttpDelete]
        public  void deleteQuestion(Guid id)
        {
            _questRepo.Delete(_questRepo.GetAll().FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

        [HttpPost("{id:Guid}")]

        public IActionResult UpdateQuestion(Guid? id , [FromBody] Question question)
        {
            var result = _questRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (result == null)
                return NotFound(new { message = "Question not found" });
            
            result.title = question.title;
            result.description = question.description;
            result.type = question.type;
            result.score = question.score;
            result.duration = question.duration;
            result.tag = question.tag;
            result.domain_id = question.domain_id;
            result.difficulty = question.difficulty;

            _questRepo.Update(result);
            return Ok(new { message = "Question updated" });
           //context.Questions.Update(result);
           // _context.SaveChanges();


        }



    }
}
