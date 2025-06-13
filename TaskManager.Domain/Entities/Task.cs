using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Enums;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities;

public sealed class Task : BaseEntity
{
    public string UserId { get; set; }
    public User User { get; private set; } 
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Status Status { get; private set; }

    public Task(string title, string description, User user)
    {
        UserId = user.Id;
        User = user;
        Title = title;
        Description = description;
        Status = new Status();
        CreatedAt = DateTime.UtcNow;
    }

    public void ChangeTask(string? title = null, string? description = null)
    {
        UpdatedAt = DateTime.UtcNow;
        if (title is not null) Title = title;
        if (description is not null) Description = description;
    }

    public void ChangeUser(User newUser)
    {
        UpdatedAt = DateTime.UtcNow;
        if (User.Id == newUser.Id) throw new InvalidOperationException("Não é possivel alterar o responsável de uma tarefa para ele proprio");
        User = newUser;
        UserId = newUser.Id.ToString();
    }

    public void ContinueTaskWorkflow(StatusTask newStatus)
    {
        UpdatedAt = DateTime.UtcNow;
        Status = Status.ChangeStatus(newStatus);
    }
}
