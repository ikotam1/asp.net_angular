using System;

namespace Application.Interfaces.Response;

public interface IResult
{
    bool IsSuccess { get; set; }

    string? Message { get; set; }
}
