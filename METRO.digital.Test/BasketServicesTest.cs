using AutoMapper;
using METRO.digital.Contracts;
using METRO.digital.Dtos;
using METRO.digital.Models;
using METRO.digital.Services;
using Moq;
using Xunit.Sdk;

namespace METRO.digital.Test;

public class BasketServicesTest
{
    private readonly Mock<IBasketRepository> _basketRepository;
    private readonly Mock<IMapper> _mapper;
    private readonly IBasketServices _basketServices;

    public BasketServicesTest()
    {
        _basketRepository = new Mock<IBasketRepository>();
        _mapper = new Mock<IMapper>();
        _basketServices = new BasketServices(_basketRepository.Object, _mapper.Object);
    }

    [Fact]
    public void getBasket_getBasketWithInvalidBasketId_returnNullReferenceException()
    {
        //Arrange
        var id = 100L;
        Basket? basket = null;
        _basketRepository.Setup(repo => repo.GetBasket(id)).Returns(basket);
        
        //Action & Assert
        Assert.Throws<NullReferenceException>(() => _basketServices.GetBasket(id));
    }
    
    [Fact]
    public void getBasket_getBasketWithValidBasketId_returnBasketReadDto()
    {
        //Arrange
        var id = 100L;
        var basket = new Basket { Id = 100L };
        var basketReadDto = new BasketReadDto { Id = 100L };
        _basketRepository.Setup(repo => repo.GetBasket(id)).Returns(basket);
        _mapper.Setup(m => m.Map<BasketReadDto>(basket)).Returns(basketReadDto);
        
        //Action
        var result = _basketServices.GetBasket(id);

        //Assert
        Assert.Equal(100L, result.Id);
    }
    
    [Fact]
    public void createBasket_createBasketWithValidData_returnBasketId()
    {
        //Arrange
        var basketWriteDto = new BasketWriteDto { Customer = "customer", PaysVat = true };
        var basket = new Basket { Id = 1L, Customer = basketWriteDto.Customer, PaysVat = basketWriteDto.PaysVat };
        _mapper.Setup(m => m.Map<Basket>(basketWriteDto)).Returns(basket);
        
        //Action
        var result = _basketServices.CreateBasket(basketWriteDto);

        //Assert
        Assert.Equal(1L, result);
    }
    
    [Fact]
    public void updateBasket_updateBasketWithInvalidBasketId_returnNullReferenceException()
    {
        //Arrange
        var id = 100L;
        Basket? basket = null;
        _basketRepository.Setup(repo => repo.GetBasket(id)).Returns(basket);
        
        //Action & Assert
        Assert.Throws<NullReferenceException>(() => _basketServices.GetBasket(id));
    }
    
    [Fact]
    public void updateBasket_updateBasketWithValidBasketId_returnNullReferenceException()
    {
        //Arrange
        var id = 100L;
        var status = "closed";
        Basket? basket = new Basket {Id = 100L, Status = status };
        _basketRepository.Setup(repo => repo.GetBasket(id)).Returns(basket);
        
        //Action
        _basketServices.UpdateBasket(id, status);
        
        //Assert
        Assert.Equal(status, basket.Status);
    }
}