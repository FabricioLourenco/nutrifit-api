using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Interfaces.Infra.Data
{
    public interface IAsyncRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> Query();
        Task SaveChangesAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
