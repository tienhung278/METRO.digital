using System.Data;
using AutoMapper;
using METRO.digital.Contracts;
using METRO.digital.Dtos;
using METRO.digital.Models;

namespace METRO.digital.Services;

public class BasketServices : IBasketServices
{
    private readonly IBasketRepository _basketRepository;
    private readonly IMapper _mapper;

    public BasketServices(IBasketRepository basketRepository, IMapper mapper)
    {
        _basketRepository = basketRepository;
        _mapper = mapper;
    }

    public BasketReadDto GetBasket(long id)
    {
        var basket = _basketRepository.GetBasket(id);

        if (basket == null)
        {
            throw new NullReferenceException("Basket was not found");
        }
        
        return _mapper.Map<BasketReadDto>(basket);;
    }

    public long CreateBasket(BasketWriteDto basketWriteDto)
    {
        var basket = _mapper.Map<Basket>(basketWriteDto);
        _basketRepository.CreateBasket(basket);
        
        return basket.Id;
    }

    public void UpdateBasket(long id, string? status)
    {
        var basket = _basketRepository.GetBasket(id);

        if (basket == null)
        {
            throw new NullReferenceException("Basket was not found");
        }

        basket.Status = status;
        _basketRepository.UpdateBasket(basket);
    }
}