using DAL.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Reponse
{
    public class Choice : BaseEntity
    {
        public string? choice { get; set; }
        public Question? question { get; set; }
        public bool isTrue { get; set; }
       
    }
}
