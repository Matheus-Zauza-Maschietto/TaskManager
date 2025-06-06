using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Contracts.Repositories;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Infra.PostgreSQL.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Core.Task?> GetTaskByIdAsync(int id)
    {
        return _context.Tasks.FirstOrDefault(p => p.Id ==id);
    }

    public async Task<Core.Task> CreateTaskAsync(Core.Task task)
    {
        return _context.Tasks.Add(task).Entity;
    }

    public async Task<Core.Task> DeleteTaskAsync(Core.Task task)
    {
        return _context.Tasks.Remove(task).Entity;
    }

    public async Task<ICollection<Core.Task>> GetTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Core.Task> UpdateTaskAsync(Core.Task task)
    {
        return _context.Tasks.Update(task).Entity;
    }
}
