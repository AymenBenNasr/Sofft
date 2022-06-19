using DAL.Entities.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Candidates
{
    public class Candidat : User
    {
        public IEnumerable<Experience>? experiences { get; set; }
        public ICollection<Postulation> Postulations { get; set; }
    }
}
