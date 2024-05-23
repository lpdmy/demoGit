namespace TeachMate.Domain;
public static class GuidExtensions
{
    public static bool IsNullOrEmpty(this Guid? guid)
    {
        return guid == null || guid == Guid.Empty;
    }
    public static bool IsNotNullOrEmpty(this Guid? guid)
    {
        return !IsNullOrEmpty(guid);
    }
}