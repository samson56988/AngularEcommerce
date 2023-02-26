using AngularEcommerce.Entity;
using Microsoft.EntityFrameworkCore;

namespace AngularEcommerce.Core.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null) 
            { 
               query = query.Where(spec.Criteria); // P => P.ProductTypeId == Id 
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
              
            return query;
        }
    }
}
