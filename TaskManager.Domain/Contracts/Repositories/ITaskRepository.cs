using System;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Domain.Contracts.Repositories;

public interface ITaskRepository
{
    Task<Core.Task?> GetTaskByIdAsync(int id);
    Task<ICollection<Core.Task>> GetTasksAsync();
    Task<Core.Task> UpdateTaskAsync(Core.Task task);
    Task<Core.Task> CreateTaskAsync(Core.Task task);
    Task<Core.Task> DeleteTaskAsync(Core.Task task);
}
