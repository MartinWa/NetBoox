using System;
using System.Linq;
using AutoMapper;
using Domain;
using Repository.Abstract;

namespace NetBoox.AutoMapper
{
    public class GenreNameLookupResolver : ValueResolver<Book, string>
    {
        private readonly IDataCache _dataCache;

        public GenreNameLookupResolver(IDataCache dataCache)
        {
            _dataCache = dataCache;
            _dataCache.SetNewDefaultAbsoluteExpiration(DateTimeOffset.Now.AddSeconds(10));
        }

        protected override string ResolveCore(Book source)
        {
            var genre = _dataCache.Get<Genre>().SingleOrDefault(g => g.GenreId == source.GenreId);
            return genre == null ? "" : genre.GenreName;
        }
    }
}