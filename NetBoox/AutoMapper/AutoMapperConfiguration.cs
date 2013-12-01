using System.Collections.Generic;
using AutoMapper;
using Domain;
using NetBoox.ViewModels;

namespace NetBoox.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.BookName))
                .ForMember(dest => dest.GenreName, opt => opt.ResolveUsing<GenreNameLookupResolver>())
                .ForMember(dest => dest.GenreList, opt => opt.ResolveUsing<GenreListCreator>());
            Mapper.CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Title));
            Mapper.CreateMap<Genre, GenreViewModel>();
            Mapper.CreateMap<GenreViewModel, Genre>();
            Mapper.CreateMap<Genre, GenreDetailsViewModel>()
                .ForMember(dest => dest.GenreViewModel, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.BookViewModelList, opt => opt.Ignore())
                .ForMember(dest => dest.BookViewModel, opt => opt.Ignore());
            Mapper.CreateMap<IEnumerable<Book>, GenreDetailsViewModel>()
                .ForMember(dest => dest.GenreViewModel, opt => opt.Ignore())
                .ForMember(dest => dest.BookViewModelList, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.BookViewModel, opt => opt.Ignore());
        }
    }
}