using System.Collections.Generic;

namespace Repository.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T FindById(int? id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}