using MicroBank.Common.Models;
using MicroBank.Common.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroBank.Common.Repository
{
    public interface IEfRepository<T1, T2> where T1 : BaseEntity<T2>
    {
        Task<T1> GetByIdAsync(T2 id, params Expression<Func<T1, object>>[] includes);
        Task<T1> FindByAsync(Expression<Func<T1, bool>> expression, params Expression<Func<T1, object>>[] includes);
        Task<T1> FindDeletedByAsync(Expression<Func<T1, bool>> expression, params Expression<Func<T1, object>>[] includes);
        Task<IReadOnlyList<T1>> ListAllAsync(Expression<Func<T1, bool>> expression = null);
        Task<(IReadOnlyList<T1>, int)> ListAsync(ISpecification<T1> spec);
        Task<T1> AddAsync(T1 entity);
        Task UpdateAsync(T1 entity);
        Task UpdateRangeAsync(IEnumerable<T1> entities);
        Task DeleteAsync(T1 entity);
        Task<int> CountAsync(ISpecification<T1> spec);
        Task<int> CountAsync(Expression<Func<T1, bool>> expression);
    }
}
