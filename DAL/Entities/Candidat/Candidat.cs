using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Candidat
{
    public class Candidat : User
    {
        public IEnumerable<Technologie>? technologies { get; set; }
        public byte resume { get; set;}
        public int test { get; set; }

          
    }
}
