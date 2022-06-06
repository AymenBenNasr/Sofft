using DAL.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Reponse
{
    public class Code : BaseEntity
    {
        public string? codeResponse { get; set; }
        public Question Question { get; set; }
       
    }
}
