using System;

namespace TaskManager.Application.UseCases.User.CreateUser;

public record CreateUserResponse(string Email, string FullName);
