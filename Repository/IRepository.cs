using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T FindById(int id);
        T FindById(int? id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}