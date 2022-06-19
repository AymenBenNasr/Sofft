using DAL.Entities.Candidates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.JobOffer
{
    public class Postulation
    {
        public string JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; }

        public string CandidId { get; set; }
        public Candidat Candidat { get; set; }

        public string State { get; set; }
        public byte[] ResumePost { get; set; }
    }
}
