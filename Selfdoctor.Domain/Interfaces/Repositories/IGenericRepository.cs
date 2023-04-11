using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(List<Expression<Func<T, object>>> includes = null!);
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includes = null!);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includes = null!);
        Task<T> AddAsync(T entity);
        T Update(T oldEntity, T newEntity);
        void Delete(T entity);  
    }
}
