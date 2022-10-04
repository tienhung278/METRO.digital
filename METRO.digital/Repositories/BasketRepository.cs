using METRO.digital.Contracts;
using METRO.digital.Models;
using Microsoft.EntityFrameworkCore;

namespace METRO.digital.Repositories;

public class BasketRepository : RepositoryBase<Basket>, IBasketRepository
{
    private readonly RepositoryContext _context;
    
    public BasketRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public ICollection<Basket> GetBaskets(QueryParameter parameter)
    {
        return GetItemsByPage(FindAll(), parameter).ToList();
    }

    public Basket? GetBasket(long id)
    {
        return FindByCondition(b => b.Id == id)
            .Include(b => b.Articles)
            .FirstOrDefault();
    }

    public void CreateBasket(Basket basket)
    {
        Add(basket);
        Save();
    }

    public void UpdateBasket(Basket basket)
    {
        Update(basket);
        Save();
    }

    public void DeleteBasket(Basket basket)
    {
        Delete(basket);
        Save();
    }

    private void Save()
    {
        _context.SaveChanges();
    }
}