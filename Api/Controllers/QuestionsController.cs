using Application.Authorization;
using Application.Interfaces.Questions;
using Application.Repositories.Questions;
using AutoMapper;
using DAL.Dtos.QuestionDto;
using DAL.Entities;
using DAL.Entities.Questions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        //Questions
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Question>> getAll()
        {
            try
            {
                return _context.Questions.ToArray();


            }
            catch (Exception ex)
            {
                return new List<Question>();
            }
        }

        //QcmQuestions
        [HttpGet]
        [Route("Qcm")]
        public async Task<IEnumerable<Question>> getAllQcm()
        {
            try
            {
                return _context.Questions.OfType<QcmQuestion>(); ;


            }
            catch (Exception ex)
            {
                return new List<QcmQuestion>();
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<Question> addQuestion([FromBody] QuestionRequestDto question)
        {
            var _question = new QcmQuestion();
            _question.description = question.description;
            _question.title = question.title;
            _question.duration = question.duration;
            _question.difficulty = question.difficulty;
            _question.score = question.score;
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



        }





    }


}
