using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Contracts.Repositories;

namespace TaskManager.Infra.PostgreSQL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Domain.Aggregates.User?> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Domain.Aggregates.User> CreateUser(Domain.Aggregates.User user)
    {
        return _context.Users.Add(user).Entity;
    }
}
