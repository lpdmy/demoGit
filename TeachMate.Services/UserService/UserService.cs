using Microsoft.EntityFrameworkCore;
using TeachMate.Domain;
using BC = BCrypt.Net.BCrypt;

namespace TeachMate.Services;
public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }
    public async Task<AppUser?> GetUserById(Guid id)
    {
        var appUser = await _context.AppUsers
            .FirstOrDefaultAsync(u => u.Id == id);

        await MapRelatedDataToAppUser(appUser);

        return appUser;
    }
    public async Task<AppUser?> GetUserByUsernameOrEmail(string usernameOrEmail)
    {
        var appUser = usernameOrEmail.IsEmail()
            ? await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == usernameOrEmail)
            : await _context.AppUsers.FirstOrDefaultAsync(u => u.Username == usernameOrEmail);

        await MapRelatedDataToAppUser(appUser);

        return appUser;
    }
    public async Task<AppUser> CreateUser(AppUser appUser)
    {
        appUser.Password = BC.HashPassword(appUser.Password);

        switch (appUser.UserRole)
        {
            case UserRole.Tutor:
                appUser.Tutor = new Tutor { DisplayName = appUser.DisplayName };
                break;
            case UserRole.Learner:
                appUser.Learner = new Learner { DisplayName = appUser.DisplayName };
                break;
        }

        _context.Add(appUser);
        await _context.SaveChangesAsync();

        return appUser;
    }
    public async Task<AppUser> UpdateUser(AppUser appUser)
    {
        _context.Update(appUser);
        await _context.SaveChangesAsync();

        return appUser;
    }
    public async Task<AppUser?> DisableUser(Guid id)
    {
        var appUser = await GetUserById(id);

        if (appUser != null)
        {
            appUser.IsDisabled = true;
            await _context.SaveChangesAsync();
        }

        return appUser;
    }
    private async Task MapRelatedDataToAppUser(AppUser? appUser)
    {
        if (appUser == null)
        {
            return;
        }

        switch (appUser.UserRole)
        {
            case UserRole.Tutor:
                appUser.Tutor = await _context.Tutors
                    .Include(x => x.CreatedModules)
                    .FirstOrDefaultAsync(x => x.Id == appUser.Id);
                break;
            case UserRole.Learner:
                appUser.Learner = await _context.Learners
                    .Include(x => x.EnrolledModules)
                    .FirstOrDefaultAsync(x => x.Id == appUser.Id);
                break;
        }
    }
}
