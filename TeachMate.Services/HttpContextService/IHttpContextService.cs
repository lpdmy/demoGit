using TeachMate.Domain;

namespace TeachMate.Services;
public interface IHttpContextService
{
    Task<AppUser?> GetAppUser();
    Task<AppUser> GetAppUserAndThrow();
}