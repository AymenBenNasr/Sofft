using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Auth
{
    public class EmployerRegisterDto
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string password { get; set; }
        public string password_confirm { get; set; }
        public DateTime birthdate { get; set; }
        string? companyName { get; set; }
        string? title { get; set; }
        string? companyWebsite { get; set; }


    }
}
