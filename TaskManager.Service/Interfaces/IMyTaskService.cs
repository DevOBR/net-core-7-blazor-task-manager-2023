using TaskManager.Share.Models;

namespace TaskManager.Service.Interfaces
{
    public interface IMyTaskService
	{
		Task<MyTaskDto> GetMyTaskByIdAsync(int id, CancellationToken cancellationToken);
		Task<IEnumerable<MyTaskDto>> GetMyTasksAll(bool asNoTracking, CancellationToken cancellationToken);
        Task CreateMyTaskAsync(MyTaskDto myTaskDto, CancellationToken cancellationToken);
        Task<bool> EditMyTaskAsync(MyTaskDto myTaskDto, CancellationToken cancellationToken);
        Task<bool> DeleteMyTaskByIdAsync(int id, CancellationToken cancellationToken);

    }
}

