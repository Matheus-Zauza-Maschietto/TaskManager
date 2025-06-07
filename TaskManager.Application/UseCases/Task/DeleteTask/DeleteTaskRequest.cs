using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Application.UseCases.Task.DeleteTask;

public record class DeleteTaskRequest(int TaskId);
