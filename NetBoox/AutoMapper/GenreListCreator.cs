using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using Repository;

namespace NetBoox.AutoMapper
{
    public class GenreListCreator : ValueResolver<Book, IEnumerable<SelectListItem>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreListCreator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override IEnumerable<SelectListItem> ResolveCore(Book source)
        {

            var genres = _unitOfWork.Repository<Genre>().Get();

            return genres.Select(
                    genre =>
                        new SelectListItem
                        {
                            Text = genre.GenreName,
                            Value = genre.GenreId.ToString(CultureInfo.InvariantCulture)
                        });
        }
    }
}