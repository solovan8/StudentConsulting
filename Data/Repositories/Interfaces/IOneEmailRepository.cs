using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentConsulting.Models;

namespace StudentConsulting.Data
{
    public interface IOneEmailRepository<T> : IRepository<T>
    {
        T GetItemByEmail(string email);
    }
}
