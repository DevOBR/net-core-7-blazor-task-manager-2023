using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Repository.Interfaces;
using TaskManager.Repository.Specifications;

namespace TaskManager.Repository.Repositories
{
    public class Repository<T, K> : IRepository<T, K> where T : EntityBase
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async virtual Task AddAsync(T entity, CancellationToken cancellationToken)
            => await _dataContext.Set<T>().AddAsync(entity, cancellationToken);

        public virtual void Delete(T entity)
            => _dataContext.Set<T>().Remove(entity);

        public virtual void Edit(T entity)
            => _dataContext.Entry(entity).State = EntityState.Modified;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
            => await _dataContext.SaveChangesAsync(cancellationToken);

        public virtual async Task<T?> GetByIdAsync(K id, CancellationToken cancellationToken)
        {
            return await _dataContext.Set<T>().FindAsync(id, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<List<T>> ListAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            if (!asNoTracking)
                return await _dataContext.Set<T>().ToListAsync(cancellationToken);

            return await _dataContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator.GetQuery<T>(_dataContext.Set<T>().AsQueryable(),
                spec);
        }
    }
}

