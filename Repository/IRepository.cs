using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> Get();
        T FindById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
    }
}