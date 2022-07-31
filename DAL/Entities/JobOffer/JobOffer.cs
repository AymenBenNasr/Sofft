using DAL.Entities.Candidates;
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
        public string? JobOfferTitle { get; set; }
        public string? Description { get; set; }
        public bool? Remote { get; set; }
        public double? Salary { get; set; }
        public int? AvailablePlaces { get; set; }
        public bool? IsActive { get; set; }
        public Guid? EmployerId { get; set; }
        public virtual Employer? Employer { get; set; }
        public Technologie? Technologies { get; set; }
        public ICollection<Postulation>? Postulations { get; set; }


    }

}