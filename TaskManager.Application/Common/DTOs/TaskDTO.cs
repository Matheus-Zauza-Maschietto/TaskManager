using System;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Application.Common.DTOs;

public class TaskDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public TaskDTO(int id, string title, string description, string userId, DateTime createdAt, DateTime? updatedAt = null)
    {
        Id = id;
        Title = title;
        Description = description;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static TaskDTO FromEntity(Core.Task task)
    {
        TaskDTO taskDto = new TaskDTO(
            task.Id,
            task.Title,
            task.Description,
            task.UserId.ToString(),
            task.CreatedAt,
            task.UpdatedAt
        );

        return taskDto;
    }
}
