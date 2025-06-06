using System;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Domain.Contracts;

public interface ITaskRepository : IBaseRepository
{
    Task<Core.Task?> GetTaskByIdAsync(int id);
    Task<Core.Task> GetTasksAsync();
    Task<Core.Task> CreateTaskAsync(Core.Task task);
    Task<Core.Task> DeleteTaskAsync(Core.Task task);
}
