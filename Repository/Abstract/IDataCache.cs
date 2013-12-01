using System;
using System.Collections.Generic;

namespace Repository.Abstract
{
    public interface IDataCache
    {
        IEnumerable<T> Get<T>() where T : class;
        void SetNewDefaultAbsoluteExpiration(DateTimeOffset absoluteExpiration);
        void Remove<T>();
    }
}