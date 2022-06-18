using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.JobOffer
{
    public class JobOffer : BaseEntity
    {
        [Key]
        public Guid jobOfferId { get; set; }
        [Required]
        public string jobOfferTitle { get; set; }
        public string description { get; set; }
        public bool remote { get; set; }
        public double salary { get; set; }
        public int availablePlaces { get; set; }
        public bool isActive { get; set; }
        [Required]
        public Employer createdBy { get; set; }

    }

}