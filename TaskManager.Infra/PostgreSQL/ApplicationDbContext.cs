using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Domain.Aggregates;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Infra.PostgreSQL;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Core.Task> Tasks { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

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

}
