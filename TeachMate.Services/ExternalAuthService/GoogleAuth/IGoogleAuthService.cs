using TeachMate.Domain;

namespace TeachMate.Services;
public interface IGoogleAuthService
{
    Task<ExternalLoginUserInfo> GoogleSignIn(GoogleSignInVM model);
}