using AutoMapper;
using METRO.digital.Contracts;
using METRO.digital.Dtos;
using METRO.digital.Models;
using METRO.digital.Services;
using Moq;

namespace METRO.digital.Test;

public class ArtIcleServiceTest
{
    private readonly Mock<IBasketRepository> _basketRepository;
    private readonly Mock<IArtIcleRepository> _articleRepository;
    private readonly Mock<IMapper> _mapper;
    private readonly IArtIcleServices _artIcleServices;

    public ArtIcleServiceTest()
    {
        _articleRepository = new Mock<IArtIcleRepository>();
        _basketRepository = new Mock<IBasketRepository>();
        _mapper = new Mock<IMapper>();
        _artIcleServices = new ArtIcleServices(_articleRepository.Object, _basketRepository.Object,
            _mapper.Object);
    }
    
    [Fact]
    public void createArtIcle_createArtIcleWithInvalidBasketId_returnNullReferenceException()
    {
        //Arrange
        var id = 100L;
        Basket? basket = null;
        var articleWriteDto = new ArticleWriteDto();
        _basketRepository.Setup(repo => repo.GetBasket(id)).Returns(basket);
        
        //Action && Assert
        Assert.Throws<NullReferenceException>(() =>
            _artIcleServices.CreateArtIcle(id, articleWriteDto));

    }
    
    [Fact]
    public void createArtIcle_createArtIcleWithValidBasketId_returnNullReferenceException()
    {
        //Arrange
        var id = 100L;
        Basket? basket = new Basket();
        var articleWriteDto = new ArticleWriteDto { Article = "article", Price = 10D };
        var article = new ArtIcle
            { Id = 1L, Article = articleWriteDto.Article, Price = articleWriteDto.Price };
        _basketRepository.Setup(repo => repo.GetBasket(id)).Returns(basket);
        _mapper.Setup(m => m.Map<ArtIcle>(articleWriteDto)).Returns(article);
        
        //Action
        var result = _artIcleServices.CreateArtIcle(id, articleWriteDto);
        
        //Assert
        Assert.Equal(1L, result);
    }
}