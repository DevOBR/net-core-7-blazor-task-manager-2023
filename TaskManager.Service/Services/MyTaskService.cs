using TaskManager.Data.Entities;
using TaskManager.Repository.Interfaces;
using TaskManager.Service.Interfaces;
using TaskManager.Share.Models;

namespace TaskManager.Service.Services
{
    public class MyTaskService : IMyTaskService
	{
        private readonly IMyTaskRepository _myTaskRepository;

        public MyTaskService(IMyTaskRepository myTaskRepository)
		{
            _myTaskRepository = myTaskRepository;
        }

        public async Task<MyTaskDto> GetMyTaskByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _myTaskRepository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);

            return result != null ? GetMyTaskDto(result) : new MyTaskDto();
        }

        public async Task<IEnumerable<MyTaskDto>> GetMyTasksAll(bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            var result = await _myTaskRepository.ListAsync(asNoTracking, cancellationToken);
            return result.Select(Extensions.ToMyTaskModel);
        }

        public async Task CreateMyTaskAsync(MyTaskDto myTaskDto, CancellationToken cancellationToken)
        {
            var dbTask = GetMyTask(myTaskDto);

            await _myTaskRepository.AddAsync(dbTask, cancellationToken);
            await _myTaskRepository.SaveChangesAsync(cancellationToken);

            myTaskDto.Id = dbTask.Id;
        }

        public async Task<bool> EditMyTaskAsync(MyTaskDto myTaskDto, CancellationToken cancellationToken = default)
        {
            var task = await _myTaskRepository.GetByIdAsync(myTaskDto.Id, cancellationToken).ConfigureAwait(false);

            if (task is null)
                return false;

            task.Description = myTaskDto.Description;
            task.Date = myTaskDto.Date;
            task.IsCompleted = myTaskDto.IsCompleted;

            _myTaskRepository.Edit(task);
            await _myTaskRepository.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteMyTaskByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var task = await _myTaskRepository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);

            if (task is null)
                return false;

            _myTaskRepository.Delete(task);
            await _myTaskRepository.SaveChangesAsync(cancellationToken);
            return true;

        }

        #region Private Methods
        private static MyTask GetMyTask(MyTaskDto myTaskDto)
        {
            return new MyTask
            {
                Id = myTaskDto.Id,
                Description = myTaskDto.Description,
                Date = myTaskDto.Date,
                IsCompleted = myTaskDto.IsCompleted
            };
        }

        private static MyTaskDto GetMyTaskDto(MyTask result)
        {
            return new MyTaskDto
            {
                Id = result.Id,
                Description = result.Description,
                Date = result.Date,
                IsCompleted = result.IsCompleted
            };
        }
        #endregion

    }
}

