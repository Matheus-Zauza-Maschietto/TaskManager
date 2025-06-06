using System;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.ValueObjects;

public record Status
{
    public StatusTask StatusTask { get; set; }

    public Status()
    {
        StatusTask = StatusTask.Backlog;
    }

    public Status ChangeStatus(StatusTask newStatus)
    {
        if ((int)StatusTask > (int)newStatus) throw new InvalidOperationException("Não é possivel voltar a tarefa para um status anterior.");
        return this with { StatusTask = newStatus };
    }
}
