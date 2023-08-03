using TaskManager.Data.Entities;

namespace TaskManager.Repository.Interfaces
{
    public interface IRepository<T, K> where T : EntityBase
    {
        Task<T?> GetByIdAsync(K id, CancellationToken cancellationToken);
        IQueryable<T> ApplySpecification(ISpecification<T> spec);
        Task<List<T>> ListAsync(bool asNoTracking, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Delete(T entity);
        void Edit(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}