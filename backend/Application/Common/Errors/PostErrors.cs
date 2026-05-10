namespace Application.Common.Errors;

public static class PostErrors
{
    public const string PostNotFoundCode = "Post.NotFound";

    public static readonly ErrorRecord PostNotFound = new(PostNotFoundCode, "The specified post was not found.");

    public static readonly ErrorRecord CreatePostFailed = new("Post.CreateFailed", "Failed to create the post.");
}
