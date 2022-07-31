using Application.Interfaces;
using Application.Interfaces.JobOfferInterface;
using DAL.Entities.JobOffer;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.JobOffers
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOffer
    {
        AppDbContext _context;

        public JobOfferRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
