using Microsoft.EntityFrameworkCore;
using Selfdoctor.Domain.Interfaces.Repositories;
using Selfdoctor.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> table = _dbContext.Set<T>();
            if (includes != null) table = includes.Aggregate(table, (content, include) => content.Include(include));
            return await table.Where(filter).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> table = _dbContext.Set<T>();
            if (includes != null) table = includes.Aggregate(table, (content, include) => content.Include(include));
            return await table.Where(filter).FirstOrDefaultAsync() ?? null!;
        }

        public async Task<IEnumerable<T>> GetAllAsync(List<Expression<Func<T, object>>> includes = null)
        {
            IQueryable<T> table = _dbContext.Set<T>();
            if (includes != null) table = includes.Aggregate(table, (content, include) => content.Include(include));
            return await table.ToListAsync();
        }

        public T Update(T oldEntity, T newEntity)
        {
            _dbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            return newEntity;
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
