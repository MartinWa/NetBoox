using System;
using System.Collections;
using DataAccess;

namespace Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly IBooksContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IBooksContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(T).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<T>)_repositories[type];
            }
            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context));
            return (IRepository<T>)_repositories[type];
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
