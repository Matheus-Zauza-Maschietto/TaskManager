using System;
using TaskManager.Domain.Aggregates;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class Task
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public StatusTask Status { get; set; }
}
