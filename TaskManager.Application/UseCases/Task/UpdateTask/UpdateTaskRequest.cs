using Microsoft.AspNetCore.Mvc;
using System;

namespace TaskManager.Application.UseCases.Task.UpdateTask;

public record UpdateTaskRequest([FromRoute]int TaskId, string Title, string Description);
