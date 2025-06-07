using Microsoft.AspNetCore.Identity;
using System;
using System.Runtime.ConstrainedExecution;
using Core = TaskManager.Domain.Entities;

namespace TaskManager.Domain.Aggregates;

public class User : IdentityUser
{
    public ICollection<Core.Task> Tasks { get; set; } = [];

    public User(string email, string firstName, string lastName)
        : base(email)
    {
        Email = email;
        this.UserName = firstName.Replace(" ", "-") + "-" + lastName.Replace(" ", "-");
    }

    public User()
    {
        
    }
}
