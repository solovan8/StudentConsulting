using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentConsulting.Data
{
    public interface IStringIdRepository<T> : IOneEmailRepository<T>
    {
        T GetItemByStringId(string id);
    }
}
