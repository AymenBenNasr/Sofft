using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos.QuestionDto
{
    public class QuestionRequestDto
    {
        
        public string? description;
        public string? title;
        public int? duration;
        public float? score { get; set; }
        public string? difficulty { get; set; }
        public string? tag { get; set; }
    }
}
