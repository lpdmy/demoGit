namespace TeachMate.Domain;
public static class AppUserExtensions
{
    public static string ToCustomRole(this AppUser user)
    {
        return user.UserRole switch
        {
            UserRole.Admin => CustomRoles.Admin,
            UserRole.Tutor => CustomRoles.Tutor,
            UserRole.Learner => CustomRoles.Learner,
            _ => throw new NotImplementedException()
        };
    }
}
