using MicroBank.Common.Models;
using MicroBank.Common.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroBank.Common.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1">Entity object</typeparam>
    /// <typeparam name="T2">ID type (f.e. Guid, int, string)</typeparam>
    public class EfRepository<T1, T2> : IEfRepository<T1, T2> where T1 : BaseEntity<T2>
    {
        protected readonly DbContext _dbContext;

        protected EfRepository()
        {

        }

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T1> GetByIdAsync(T2 id, params Expression<Func<T1, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<T1>().AsQueryable(),
             (current, include) => current.Include(include)).FirstOrDefaultAsync(entity => entity.Id.Equals(id)).ConfigureAwait(true);
        }

        public virtual async Task<T1> FindByAsync(Expression<Func<T1, bool>> expression, params Expression<Func<T1, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<T1>().AsQueryable(),
             (current, include) => current.Include(include)).FirstOrDefaultAsync(expression).ConfigureAwait(true);
        }

        public virtual async Task<T1> FindDeletedByAsync(Expression<Func<T1, bool>> expression, params Expression<Func<T1, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<T1>().AsQueryable(),
             (current, include) => current.Include(include)).IgnoreQueryFilters().FirstOrDefaultAsync(expression).ConfigureAwait(true);
        }

        public async Task<T1> GetDeletedByIdAsync(T2 id, params Expression<Func<T1, object>>[] includes)
        {
            return await includes.Aggregate(_dbContext.Set<T1>().AsQueryable(),
                (current, include) => current.Include(include)).IgnoreQueryFilters().FirstOrDefaultAsync(entity => entity.Id.Equals(id))
                .ConfigureAwait(true);
        }

        public virtual async Task<IReadOnlyList<T1>> ListAllAsync(Expression<Func<T1, bool>> expression = null)
        {
            if (expression == null)
            {
                return await _dbContext.Set<T1>().ToListAsync().ConfigureAwait(true);
            }
            return await _dbContext.Set<T1>().Where(expression).ToListAsync().ConfigureAwait(true);
        }

        public virtual async Task<(IReadOnlyList<T1>, int)> ListAsync(ISpecification<T1> spec)
        {
            var query = ApplySpecification(spec);
            var totalCount = query.Count();
            // Apply paging if enabled
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip)
                             .Take(spec.Take);
            }
            return (await query.ToListAsync().ConfigureAwait(true), totalCount);
        }

        public virtual async Task<int> CountAsync(ISpecification<T1> spec)
        {
            return await ApplySpecification(spec).CountAsync().ConfigureAwait(true);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T1, bool>> expression)
        {
            return await _dbContext.Set<T1>().Where(expression).CountAsync().ConfigureAwait(true);
        }

        public virtual async Task<T1> AddAsync(T1 entity)
        {
            await _dbContext.Set<T1>().AddAsync(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);

            return entity;
        }

        public virtual async Task UpdateAsync(T1 entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            entity.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<T1> entities)
        {
            foreach (var item in entities)
            {
                item.UpdatedAt = DateTime.UtcNow;
            }
            _dbContext.UpdateRange(entities);
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);
        }

        public virtual async Task DeleteAsync(T1 entity)
        {
            _dbContext.Set<T1>().Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);
        }

        private IQueryable<T1> ApplySpecification(ISpecification<T1> spec)
        {
            return SpecificationEvaluator<T1, T2>.GetQuery(_dbContext.Set<T1>().AsQueryable(), spec);
        }

    }

}
