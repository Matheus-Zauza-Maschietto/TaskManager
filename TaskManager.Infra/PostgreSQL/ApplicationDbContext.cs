using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using TaskManager.Domain.Aggregates;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Infra.PostgreSQL;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Core.Task> Tasks { get; set; }
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor
        ) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Core.Task>().HasQueryFilter(p => p.UserId == GetSessionUserId());

        builder.Entity<Core.Task>()
        .HasOne(p => p.User)
        .WithMany(p => p.Tasks)
        .HasForeignKey(p => p.UserId);

        builder.Entity<Core.Task>()
        .ComplexProperty(p => p.Status);

        builder.Entity<User>()
        .HasMany(p => p.Tasks)
        .WithOne(p => p.User);
    }

    public override int SaveChanges()
    {
        SetUserId();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetUserId();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetUserId()
    {
        string userId = GetSessionUserId();
        foreach (var entry in ChangeTracker.Entries<Core.Task>().Where(e => e.State == EntityState.Added))
        {
            entry.Entity.UserId = userId;
        }
    }
    
    private string GetSessionUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
    }

}
