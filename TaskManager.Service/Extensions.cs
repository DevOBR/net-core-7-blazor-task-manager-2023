using TaskManager.Data.Entities;
using TaskManager.Share.Models;

namespace TaskManager.Service;

public static class Extensions
{
    public static Func<MyTask, MyTaskDto> ToMyTaskModel = model => new MyTaskDto
    {
        Id = model.Id,
        Description = model.Description,
        Date = model.Date,
        IsCompleted = model.IsCompleted
    };
}

