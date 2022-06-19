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
        public Guid JobOfferId { get; set; }
        [ForeignKey("Id")]
        public JobOffer JobOffer { get; set; }

        public Guid CandidId { get; set; }
        [ForeignKey("candidatId")]

        public Candidat Candidat { get; set; }
        public string State { get; set; }
        public byte[] ResumePost { get; set; }
    }
}
