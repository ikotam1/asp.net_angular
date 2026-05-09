using System.Text.Json.Serialization;

namespace Application.DTOs.Response;

public class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;

    [JsonIgnore]
    public string RefreshToken { get; set; } = string.Empty;
}
