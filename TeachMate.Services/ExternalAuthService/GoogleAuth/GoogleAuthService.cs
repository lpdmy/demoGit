using Microsoft.Extensions.Options;
using TeachMate.Domain;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace TeachMate.Services;
public class GoogleAuthService : IGoogleAuthService
{
    private readonly GoogleAuthConfig _googleAuthConfig;

    public GoogleAuthService(IOptions<GoogleAuthConfig> googleAuthConfig)
    {
        _googleAuthConfig = googleAuthConfig.Value;
    }
    public async Task<ExternalLoginUserInfo> GoogleSignIn(GoogleSignInVM model)
    {
        Payload payload = new();

        try
        {
            payload = await ValidateAsync(model.IdToken, new ValidationSettings
            {
                Audience = new[] { _googleAuthConfig.ClientId },
            });
        }
        catch (Exception)
        {
            throw new UnauthorizedException("Logging in with Google has failed");
        }

        return new ExternalLoginUserInfo
        {
            FirstName = payload.GivenName,
            LastName = payload.FamilyName,
            Email = payload.Email,
            ProfilePicture = payload.Picture,
            LoginProviderSubject = payload.Subject
        };
    }
}
