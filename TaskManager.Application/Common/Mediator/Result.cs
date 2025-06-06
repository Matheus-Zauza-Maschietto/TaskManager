using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Application.Common.Mediator;

public abstract record class Result
{
    public static Result<TResponse> Success<TResponse>(TResponse response, params string[] messages)
    {
        var result = new Result<TResponse>(true, response, messages);
        return result;
    }

    public static Result<TResponse> Success<TResponse>(params string[] messages)
    {
        var result = new Result<TResponse>(true, default, messages);
        return result;
    }

    public static Result<TResponse> Failure<TResponse>(params string[] messages)
    {
        var result = new Result<TResponse>(false, default, messages);
        return result;
    }
}

public record class Result<TResponse> : Result
{
    public bool IsSucess { get; set; }
    public ICollection<string> Messages { get; set; } = [];
    public TResponse? Response { get; set; }

    internal Result(bool isSuccess, TResponse? response, ICollection<string> messages)
    {
        IsSucess = isSuccess;
        Response = response;
        Messages = messages;
    }
}
