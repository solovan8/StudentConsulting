using StudentConsulting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentConsulting.Business
{
    public class DateFilter : IDateFilter
    {
        public IEnumerable<ConsultingArrange> Filter(IEnumerable<ConsultingArrange> list)
        {
            var today = DateTime.Today;

            return list.Where(d =>
            {
                if (today.CompareTo(d.Date) < 0)
                    return true;
                return false;
            });
        }
    }
}
