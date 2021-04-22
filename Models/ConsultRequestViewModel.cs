using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentConsulting.Models
{
    public class ConsultRequestViewModel
    {
        public string QueueNumber { get; set; }

        public string StudentName { get; set; }

        public bool IsBanned { get; set; }

        public int RequiredTime { get; set; }

        public ConsultType ConsultType { get; set; }

    }
}
