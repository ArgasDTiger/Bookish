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
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(a =>  $"{a.Name} {a.Surname}".Trim()).ToList()));
    }
}
