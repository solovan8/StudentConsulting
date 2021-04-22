using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentConsulting.Data
{
    public interface IManyIdRepository<T> : IRepository<T>
    {
        IEnumerable<T> GetItemsById(int Id);
    }
}
