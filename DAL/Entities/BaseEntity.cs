using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id  { get; set; } = Guid.NewGuid();
        public int? Status { get; set; } = 1 ;
        public DateTime? Created_At { get; set; } = DateTime.UtcNow;
        public DateTime? Updated_At { get; set; } 
    }
}
