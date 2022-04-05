using DAL.Entities.Candidat;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    internal class CandidatRepository : GenericRepository<Candidat>
    {
        public CandidatRepository(AppDbContext context) : base(context)
        {
        }
    }
}
