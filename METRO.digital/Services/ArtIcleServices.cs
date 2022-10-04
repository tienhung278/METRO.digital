using AutoMapper;
using METRO.digital.Contracts;
using METRO.digital.Dtos;
using METRO.digital.Models;

namespace METRO.digital.Services;

public class ArtIcleServices : IArtIcleServices
{
    private readonly IBasketRepository _basketRepository;
    private readonly IArtIcleRepository _articleRepository;
    private readonly IMapper _mapper;


    public ArtIcleServices(IArtIcleRepository articleRepository, IBasketRepository basketRepository, IMapper mapper)
    {
        _basketRepository = basketRepository;
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public long CreateArtIcle(long basketId, ArticleWriteDto articleWriteDto)
    {
        var basket = _basketRepository.GetBasket(basketId);

        if (basket == null)
        {
            throw new NullReferenceException("Basket was not found");
        }
        
        var article = _mapper.Map<ArtIcle>(articleWriteDto);
        article.BasketId = basketId;
        
        _articleRepository.CreateArtIcle(article);

        return article.Id;
    }
}