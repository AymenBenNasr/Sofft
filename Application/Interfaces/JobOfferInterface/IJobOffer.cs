using DAL.Entities.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.JobOfferInterface
{
    public interface IJobOffer : IGenericRepository<JobOffer>
    {
    }
}
