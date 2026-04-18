using System;
using Application.Interfaces.Response;

namespace Application.DTOs.Response;

// Result pattern for API responses
public class Result<T> : IResult
{
    public bool IsSuccess { get; set; }

    public string? Error { get; set; }

    public T? Value { get; }

    private Result(bool success, T? value, string? error)
    {
        IsSuccess = success;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value)
        => new(true, value, null);

    public static Result<T> Failure(string error)
        => new(false, default, error);
}

public class Result : IResult
{
    public bool IsSuccess { get; set; }

    public string? Error { get; set; }

    private Result(bool success, string? error)
    {
        IsSuccess = success;
        Error = error;
    }

    public static Result Success()
        => new(true, null);

    public static Result Failure(string error)
        => new(false, error);
}