using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Candidat
{
    public class Candidat : User
    {
        public IEnumerable<Experience>? experiences { get; set; }
        public byte resume { get; set; }


    }
}
