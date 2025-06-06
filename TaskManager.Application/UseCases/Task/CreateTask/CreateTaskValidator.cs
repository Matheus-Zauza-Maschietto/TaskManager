using FluentValidation;
using System;

namespace TaskManager.Application.UseCases.Task.CreateTask;

public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Task name is required.")
            .MaximumLength(100).WithMessage("Task name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Task description is required.")
            .MaximumLength(1000).WithMessage("Task description must not exceed 1000 characters.");
    }
}
