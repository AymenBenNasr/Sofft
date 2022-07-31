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
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string password { get; set; }
        public string password_confirm { get; set; }
        public DateTime birthdate { get; set; }
        public IEnumerable<Experience>? experiences { get; set; }

    }
}
