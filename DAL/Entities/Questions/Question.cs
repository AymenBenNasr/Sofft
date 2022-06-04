using DAL.Entities.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Questions
{

    public class Question : BaseEntity
    {
        public string? description { get; set; }
        public string? title { get; set; }
        public int? duration { get; set; }
        public float? score { get; set; }
        public string? difficulty { get; set; }
        public string? tag { get; set; } 
        public Guid employer_id { get; set; }   
        public Guid domain_id { get; set; }
        public Domain? domain { get; set; } 
        public QuestType? type { get; set; }       

    }
}
