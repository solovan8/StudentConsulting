﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentConsulting.Data
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetItems();

        T GetItem(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
