using System;
using TaskManager.Domain.Aggregates;

namespace TaskManager.Domain.Contracts.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User> CreateUser(User user);
}
