using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Enums;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities;

public sealed class Task
{
    public User User { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Status Status { get; private set; }

    public Task(User user, string title, string description, StatusTask statusTask)
    {
        User = user;
        Title = title;
        Description = description;
        Status = new Status(statusTask);
    }

    public void ChangeTask(string? title = null, string? description = null)
    {
        if (title is not null) Title = title;
        if (description is not null) Description = description;
    }

    public void ChangeUser(User newUser)
    {
        if (User.Id == newUser.Id) throw new InvalidOperationException("Não é possivel alterar o responsável de uma tarefa para ele proprio");
        User = newUser;
    }

    public void ContinueTaskWorkflow(StatusTask newStatus)
    {
        Status = Status.ChangeStatus(newStatus);
    }
}
