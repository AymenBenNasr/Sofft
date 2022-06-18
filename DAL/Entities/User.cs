using DAL.Entities.Candidat;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User : IdentityUser
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Phone_number { get; set; }
        public string? Country { get; set; }    
        public byte Profile_image { get; set; }
        [JsonIgnore]
        public string? PasswordHashed { get; set; }
        public int? Status { get; set; } = 1;
        public DateTime? Created_At { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_At { get; set; }

    }
}
