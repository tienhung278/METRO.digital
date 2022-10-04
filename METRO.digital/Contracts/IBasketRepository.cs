using METRO.digital.Models;

namespace METRO.digital.Contracts;

public interface IBasketRepository : IRepositoryBase<Basket>
{
    ICollection<Basket> GetBaskets(QueryParameter parameter);
    Basket? GetBasket(long id);
    void CreateBasket(Basket basket);
    void UpdateBasket(Basket basket);
    void DeleteBasket(Basket basket);
}