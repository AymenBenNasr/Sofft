using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employer : User
    {
        public string? CompanyName { get; set; }

        public string? Title { get; set; }
        public string? CompanyWebsite { get; set; }

    }
}
