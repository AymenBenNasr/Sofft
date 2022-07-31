using Application.Dtos.JobOfferDtos;
using Application.Interfaces.JobOfferInterface;
using Application.Repositories.JobOffers;
using AutoMapper;
using DAL.Entities.JobOffer;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobOfferController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IJobOffer _jobOfferRepo;
        private AppDbContext _context;

        public JobOfferController(IJobOffer jobOfferRepo, AppDbContext context , IMapper mapper)
        {
            _mapper = mapper;
            _jobOfferRepo = jobOfferRepo;
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<JobOffer>> getAll()
        {
            try
            {
                
                //var jos = _mapper.Map<List<JobOfferRequestDto>>(jobOffers);
                //Console.Write(jos);
                return _jobOfferRepo.GetAll(); 


            }
            catch (Exception ex)
            {
                return new List<JobOffer>();
            }
        }
        [Route("add")]
        [HttpPost]
        public async Task<JobOffer> addJobOffer([FromBody] JobOfferRequestDto newjoboffer)
        {
            var jobOffer = new JobOffer();
            jobOffer.Remote = newjoboffer.Remote;
            jobOffer.JobOfferTitle = newjoboffer.JobOfferTitle;
            jobOffer.Description = newjoboffer.Description;
            jobOffer.Salary = newjoboffer.Salary;
            jobOffer.AvailablePlaces = newjoboffer.AvailablePlaces;
            _jobOfferRepo.Add(jobOffer);
            _context.SaveChanges();
            return jobOffer;
        }

    }
}
