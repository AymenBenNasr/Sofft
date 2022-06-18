using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Questions
{
    public class QcmQuestion : Question
    {
        public int priority { get; set; }
        public ICollection<QcmResponse>? responses;

    }
}
