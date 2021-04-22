using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Models;

namespace StudentConsulting.Business
{
    public interface IRequestFilter
    {
        IEnumerable<ConsultRequestViewModel> Prioritize(int consultId);
    }
}
