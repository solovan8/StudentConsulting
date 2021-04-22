using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentConsulting.Models
{
    public class ConsultingRequest
    {
        public int Id { get; set; }

        public int ConsultingArrangeId { get; set; }

        public ConsultType ConsultType { get; set; }

        public int RequiredTime { get; set; }

        public string StudentId { get; set; }
    }
}
