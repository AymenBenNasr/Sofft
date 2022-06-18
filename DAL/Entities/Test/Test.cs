using DAL.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Test
{
    public class Test
    {
        public Guid TestId { get; set; } 
        public string title { get; set; }
        public Employer employer { get; set; }
        public Guid employerId { get; set; }
        public Guid candidatId { get; set; }
        public ICollection<Question> questions { get; set; }
    }
}
