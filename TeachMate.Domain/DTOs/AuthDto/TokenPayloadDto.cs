namespace TeachMate.Domain;
public class TokenPayloadDto
{
    public int ExpiresIn { get; set; } = 3600;
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
