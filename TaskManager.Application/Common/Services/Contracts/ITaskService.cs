using System;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Application.Common.Services.Contracts;

public interface ITaskService
{
    Task<Core.Task> GetTaskByIdAsync(int taskId);
}
