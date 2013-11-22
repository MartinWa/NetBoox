using AutoMapper;
using Domain;
using Repository;

namespace NetBoox.AutoMapper
{
    public class GenreNameLookupResolver : ValueResolver<Book, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreNameLookupResolver(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override string ResolveCore(Book source)
        {

            return _unitOfWork.Repository<Genre>().FindById(source.GenreId).GenreName;
        }
    }
}