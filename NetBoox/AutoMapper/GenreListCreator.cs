using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using Repository.Abstract;

namespace NetBoox.AutoMapper
{
    public class GenreListCreator : ValueResolver<Book, IEnumerable<SelectListItem>>
    {
        private readonly IDataCache _dataCache;

        public GenreListCreator(IDataCache dataCache)
        {
            _dataCache = dataCache;
            _dataCache.SetNewDefaultAbsoluteExpiration(DateTimeOffset.Now.AddSeconds(10));
        }

        protected override IEnumerable<SelectListItem> ResolveCore(Book source)
        {
            var genres = _dataCache.Get<Genre>();

            return genres.Select(genre => new SelectListItem
            {
                Text = genre.GenreName,
                Value = genre.GenreId.ToString(CultureInfo.InvariantCulture)
            });
        }
    }
}