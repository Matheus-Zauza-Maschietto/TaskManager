using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace TaskManager.Application.UseCases.Task.UpdateTask;

public record UpdateTaskRequest( string Title, string Description)
{
    [JsonIgnore] public int TaskId;
};
