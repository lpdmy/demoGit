namespace TeachMate.Domain;
public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base("Unauthorized")
    {

    }
    public UnauthorizedException(string message) : base(message)
    {

    }
    public UnauthorizedException(string message, Exception inner) : base(message, inner)
    {

    }
}
