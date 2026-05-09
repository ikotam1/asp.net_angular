namespace Application.Common.Errors;

public static class UserErrors
{
    public static readonly ErrorRecord UserNotFound = new ErrorRecord("User.NotFound", "User not found");
    
    public static readonly ErrorRecord EmailAlreadyExists = new ErrorRecord("User.EmailAlreadyExists", "Email already exists");

    public static readonly ErrorRecord InvalidCredentials = new ErrorRecord("User.InvalidCredentials", "Invalid email or password");
}
