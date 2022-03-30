using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.Resquests
{
    public class UserDtoRequest
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public Role Role { get; set; }
        public string? password { get; set; }
    }
}
