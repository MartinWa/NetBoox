using AutoMapper;
using Domain;
using NetBoox.ViewModels;
using Ninject;

namespace NetBoox.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.BookName))
                .ForMember(dest => dest.GenreName, opt => opt.ResolveUsing<GenreNameLookupResolver>());
            Mapper.CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Title));
            Mapper.CreateMap<Genre, GenreViewModel>();
            Mapper.CreateMap<GenreViewModel, Genre>();
        }
    }
}