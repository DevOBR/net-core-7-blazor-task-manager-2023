using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Repository.Interfaces;
using TaskManager.Repository.Specifications;

namespace TaskManager.Repository.Repositories
{
    public class MyTaskRepository : Repository<MyTask, int>, IMyTaskRepository
    {
        public MyTaskRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override Task<MyTask?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return ApplySpecification(new MyTaskById(id)).FirstOrDefaultAsync(cancellationToken);
        }
    }
}

