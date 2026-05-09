using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common.Extensions;

public static class ResultExtension
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result.Value);
        }

        var error = result.Errors.FirstOrDefault();
        if (error != null && error.Metadata.TryGetValue("Code", out var code))
        {
            return code switch
            {
                "User.NotFound" => new NotFoundObjectResult(error.Message),
                "Post.CreateFailed" => new BadRequestObjectResult(error.Message),
                _ => new ObjectResult(error.Message) { StatusCode = 500 }
            };
        }

        return new ObjectResult("An unexpected error occurred.") { StatusCode = 500 };
    }
}
