using ECommerceProjectWithWebAPI.Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceProjectWithWebAPI.DAL
{
    public interface IBaseRepository<T>where T:class,IEntity,new()
    {
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
