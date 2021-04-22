using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentConsulting.Models
{
    public class ConsultingArrange
    {
        public int Id { get; set; }

        public int LecturerId { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }
    }
}
