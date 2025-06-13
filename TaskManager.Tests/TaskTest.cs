using System;
using TaskManager.Domain.Aggregates;
using Xunit.Sdk;
using Core = TaskManager.Domain.Entities;
namespace TaskManager.Tests;

public class TaskTest
{

    [Fact]
    public void ChangeTask_UpdateTitleAndDescription_CorrectlyUpdateBothTaskProperties()
    {
        User user = new User();
        Core.Task task = new Core.Task("teste 1", "descrição 1", user);
        const string newTitle = "teste2";
        const string newDescription = "desc 2";

        task.ChangeTask(newTitle, newDescription);

        Assert.Equal(task.Description, newDescription);
        Assert.Equal(task.Title, newTitle);
    }

    [Fact]
    public void ChangeTask_NullDescription_JustTitleUpdate()
    {
        const string oldDescription = "descrição 1";
        User user = new User();
        Core.Task task = new Core.Task("teste 1", oldDescription, user);

        task.ChangeTask("teste2");

        Assert.Equal(task.Description, oldDescription);
    }

    [Fact]
    public void ChangeTask_NullTitle_JustDescriptionUpdate()
    {
        const string oldTitle = "title 1";
        User user = new User();
        Core.Task task = new Core.Task(oldTitle, "description", user);

        task.ChangeTask(description: "nova descricao");

        Assert.Equal(task.Title, oldTitle);
    }

    [Fact]
    public void ChangeUser_EqualOldUser_ThowsInvalidOperationException()
    {
        User user = new User() { Id = Guid.NewGuid().ToString() };
        Core.Task task = new Core.Task("title", "description", user);

        Assert.Throws<InvalidOperationException>(() => task.ChangeUser(user));
    }
    
    
}
