using AutoMapper;
using Domain;
using NetBoox.ViewModels;

namespace NetBoox.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.BookName));
        }
    }
}