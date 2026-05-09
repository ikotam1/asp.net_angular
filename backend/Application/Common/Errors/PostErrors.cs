namespace Application.Common.Errors;

public static class PostErrors
{
    public static readonly ErrorRecord PostNotFound = new("Post.NotFound", "The specified post was not found.");

    public static readonly ErrorRecord CreatePostFailed = new("Post.CreateFailed", "Failed to create the post.");
}
