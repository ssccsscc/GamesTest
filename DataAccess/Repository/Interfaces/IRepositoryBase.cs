using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IRepositoryBase<T>
    {
        abstract IQueryable<T> FindAll();
        abstract IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        abstract void Create(T entity);
        abstract void Update(T entity);
        abstract void Delete(T entity);
    }
}
