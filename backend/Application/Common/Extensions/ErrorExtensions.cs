using Application.Common.Errors;
using FluentResults;

namespace Application.Common.Extensions;

public static class ErrorExtensions
{
    public static Error ToError(this ErrorRecord error)
    {
        return new Error(error.Message).WithMetadata("Code", error.Code);
    }
}
