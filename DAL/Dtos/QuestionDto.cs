using DAL.Entities.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dtos
{
    public class QuestionDto
    {
        public string? description { get; set; }
        public string? title { get; set; }
        public int? duration { get; set; }
        public float? score { get; set; }
        public string? difficulty { get; set; }
        public string? tag { get; set; }
        public Guid domain_id { get; set; }
        public Domain? domain { get; set; }

    }
}
