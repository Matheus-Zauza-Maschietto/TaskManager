namespace TaskManager.Application.UseCases.User.CreateUser;

public record CreateUserRequest(string Email, string Password, string FirstName, string LastName);
