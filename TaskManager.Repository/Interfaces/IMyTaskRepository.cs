using System;
using TaskManager.Data.Entities;

namespace TaskManager.Repository.Interfaces
{
	public interface IMyTaskRepository : IRepository<MyTask, int>
	{
    }
}

