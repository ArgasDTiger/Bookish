using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Book, BookToReturnDto>()
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher.Name))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name).ToList()))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(a => $"{a.Name} {a.Surname}".Trim()).ToList()));
        CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books.Select(b => b.Title).ToList()));
        CreateMap<Author, AuthorFullNameDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}".Trim()));
        CreateMap<Genre, GenreDto>();
        CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        CreateMap<UserBasket, UserBasketDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)).ReverseMap();
    }
}