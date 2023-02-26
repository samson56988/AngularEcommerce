using AngularEcommerce.Core.Specifications;
using AngularEcommerce.Entity;

namespace AngularEcommerce.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecifications<T> specifications);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specifications);

    }
}
