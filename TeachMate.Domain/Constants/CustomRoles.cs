namespace TeachMate.Domain;
public static class CustomRoles
{
    public const string Admin = nameof(Admin);
    public const string Tutor = nameof(Tutor);
    public const string Learner = nameof(Learner);

    public const string GeneralUser = Tutor + "," + Learner;
}
