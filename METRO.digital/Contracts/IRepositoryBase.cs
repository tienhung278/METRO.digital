using System.Linq.Expressions;
using METRO.digital.Models;

namespace METRO.digital.Contracts;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expresstion);
    IQueryable<T> GetItemsByPage(IQueryable<T> collection, QueryParameter parameter);
    PageInfo<T> GetPageInfo(QueryParameter parameter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}