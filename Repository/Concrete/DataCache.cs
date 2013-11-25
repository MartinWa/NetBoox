using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class DataCache : IDataCache
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ObjectCache _cache;
        private readonly CacheItemPolicy _policy;

        public DataCache(IUnitOfWork unitOfWork, ObjectCache cache, CacheItemPolicy policy)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _policy = policy;
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            var type = typeof(T).Name;
            return _cache.Contains(type) ? (IEnumerable<T>)_cache.Get(type) : Set<T>();
        }

        public IEnumerable<T> Set<T>() where T : class
        {
            var type = typeof(T).Name;
            var data = _unitOfWork.Repository<T>().Get();
            _cache.Set(type, data, _policy);
            return data;
        }

        public void SetNewDefaultAbsoluteExpiration(DateTimeOffset absoluteExpiration)
        {
            _policy.AbsoluteExpiration = absoluteExpiration;
        }
    }
}
