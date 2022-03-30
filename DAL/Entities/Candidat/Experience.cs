using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Candidat
{
    public class Experience : BaseEntity 
    {
        public IEnumerable<Technologie> technologies { get; set; }
        public int duration { get; set;}
        
    }
}
