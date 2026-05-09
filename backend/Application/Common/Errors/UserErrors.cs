namespace Application.Common.Errors;

public static class UserErrors
{
    #region Define codes
    public const string Prefix = "User";
    public const string NotFoundCode = $"{Prefix}.NotFound";
    public const string InvalidCredentialsCode = $"{Prefix}.InvalidCredentials";
    public const string EmailAlreadyExistsCode = $"{Prefix}.EmailAlreadyExists";
    #endregion

    #region Define errors

    public static readonly ErrorRecord UserNotFound = new ErrorRecord(NotFoundCode, "User not found");

    public static readonly ErrorRecord EmailAlreadyExists = new ErrorRecord(EmailAlreadyExistsCode, "Email already exists");

    public static readonly ErrorRecord InvalidCredentials = new ErrorRecord(InvalidCredentialsCode, "Invalid email or password");

    #endregion
}
