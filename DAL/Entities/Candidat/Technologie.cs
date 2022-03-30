using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Candidat
{
    public class Technologie : BaseEntity
    {
        public string?  label { get; set; }
        public string  field { get; set; }
    }
}
