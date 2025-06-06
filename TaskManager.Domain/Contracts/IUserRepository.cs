using System;
using TaskManager.Domain.Aggregates;

namespace TaskManager.Domain.Contracts;

public interface IUserRepository
{
    Task<User> GetUserByEmail(string email);
}
