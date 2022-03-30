using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : BaseEntity
    {
        
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }
        
        public string? Country { get; set; }

        public byte profile_image { get; set; }

        [JsonIgnore]
        public string? passwordHash { get; set; }    
       
     }
}
