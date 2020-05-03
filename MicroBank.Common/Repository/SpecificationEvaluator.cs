using MicroBank.Common.Models;
using MicroBank.Common.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MicroBank.Common.Repository
{
    public static class SpecificationEvaluator<T1, T2> where T1 : BaseEntity<T2>
    {
        public static IQueryable<T1> GetQuery(IQueryable<T1> inputQuery, ISpecification<T1> specification)
        {
            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Include any string-based include statements
            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            return query;
        }
    }

}
