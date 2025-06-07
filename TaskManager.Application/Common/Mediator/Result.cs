using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Application.Common.Mediator;

public record class Result
{
    public bool IsSucess { get; set; }
    public ICollection<string> Messages { get; set; } = [];
    public object? Response { get; set; }

    private Result(bool isSuccess, object? response, ICollection<string> messages)
    {
        IsSucess = isSuccess;
        Response = response;
        Messages = messages;
    }

    public static Result Success(object response, params string[] messages)
    {
        var result = new Result(true, response, messages);
        return result;
    }

    public static Result Success(params string[] messages)
    {
        var result = new Result(true, default, messages);
        return result;
    }

    public static Result Failure(params string[] messages)
    {
        var result = new Result(false, default, messages);
        return result;
    }
}
