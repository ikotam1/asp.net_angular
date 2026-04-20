using System;
using Application.Interfaces.Response;

namespace Application.DTOs.Response;

public static class ResultCreator
{
    public static Result<T> Success<T>(T? value) => new Result<T>(true, value, null);

    public static Result Success() => new Result(true, null);

    public static Result Failure(string error) => new Result(false, error);
}

// Result pattern for API responses
public class Result<T> : IResult
{
    public bool IsSuccess { get; set; }

    public string? Message { get; set; }

    public T? Value { get; }

    internal Result(bool success, T? value, string? error)
    {
        IsSuccess = success;
        Value = value;
        Message = error;
    }
}

public class Result : IResult
{
    public bool IsSuccess { get; set; }

    public string? Message { get; set; }

    internal Result(bool success, string? error)
    {
        IsSuccess = success;
        Message = error;
    }
}