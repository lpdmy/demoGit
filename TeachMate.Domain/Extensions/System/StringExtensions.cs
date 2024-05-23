using System.Text.RegularExpressions;

namespace TeachMate.Domain;
public static class StringExtensions
{
    public static bool IsEmail(this string input)
    {
        // Regular expression pattern to validate email addresses
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(input, pattern);
    }
}
