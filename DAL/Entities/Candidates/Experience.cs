using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Candidates
{
    public class Experience : BaseEntity 
    {
        public Technologie tech { get; set; }
        public int duration { get; set;}
        
    }
}
