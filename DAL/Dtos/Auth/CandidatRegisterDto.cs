using DAL.Entities.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Auth
{
    public class CandidatRegisterDto : RegisterDto
    {
        public IEnumerable<Experience>? experiences { get; set; }
        public byte[] resume { get; set; }

    }
}
