using AutoMapper;
using METRO.digital.Dtos;
using METRO.digital.Models;

namespace METRO.digital;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Basket, BasketReadDto>();
        CreateMap<BasketWriteDto, Basket>();
        CreateMap<ArtIcle, ArticleReadDto>();
        CreateMap<ArticleWriteDto, ArtIcle>();
    }
}