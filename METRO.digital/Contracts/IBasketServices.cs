using AutoMapper;
using METRO.digital.Dtos;

namespace METRO.digital.Contracts;

public interface IBasketServices
{
    BasketReadDto? GetBasket(long id);
    long CreateBasket(BasketWriteDto basketWriteDto);
    void UpdateBasket(long id, string? status);
}