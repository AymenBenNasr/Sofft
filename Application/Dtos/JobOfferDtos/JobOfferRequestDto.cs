using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.JobOfferDtos
{
    public class JobOfferRequestDto
    {
        public string JobOfferTitle { get; set; }
        public string Description { get; set; }
        public bool Remote { get; set; }
        public double Salary { get; set; }
        public int AvailablePlaces { get; set; }
    }
}
