using System;
using TaskManager.Data.Entities;

namespace TaskManager.Repository.Interfaces
{
	public interface IMyTaskRepository : IRepository<MyTask, int>
	{
        Task<List<MyTask>> ListOrderedByDateAsync(bool asNoTracking, CancellationToken cancellationToken);
    }
}

