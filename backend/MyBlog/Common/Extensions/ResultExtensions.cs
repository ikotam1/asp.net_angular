using Application.Common.Errors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common.Extensions;

public static class ResultExtension
{
    public static IActionResult ToActionResult<T>(this Result<T> result, bool noContentOnSuccess = false)
    {
        if (result.IsSuccess)
        {
            return noContentOnSuccess 
                ? new NoContentResult()
                : new OkObjectResult(result.Value);
        }

        var error = result.Errors.FirstOrDefault();
        if (error != null && error.Metadata.TryGetValue("Code", out var code))
        {
            return code switch
            {
                UserErrors.NotFoundCode => new NotFoundObjectResult(error.Message),
                UserErrors.InvalidCredentialsCode => new UnauthorizedResult(),
                UserErrors.EmailAlreadyExistsCode => new ConflictObjectResult(error.Message),
                _ => new ObjectResult(error.Message) { StatusCode = 500 }
            };
        }

        return new ObjectResult("An unexpected error occurred.") { StatusCode = 500 };
    }
}
