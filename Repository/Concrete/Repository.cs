using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> _dbSet;
        private readonly IBooksContext _context;

        public Repository(IBooksContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return _dbSet.ToList();
        }

        public T FindById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
