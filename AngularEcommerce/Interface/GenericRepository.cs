using AngularEcommerce.Core.Specifications;
using AngularEcommerce.Data;
using AngularEcommerce.Entity;
using Microsoft.EntityFrameworkCore;

namespace AngularEcommerce.Interface
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext storeContext) 
        { 
           _context= storeContext;   
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specifications)
        {
            return await ApplySpecification(specifications).ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> specifications)
        {
            return await ApplySpecification(specifications).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> specifications) 
        { 
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specifications); 
        }
    }
}
