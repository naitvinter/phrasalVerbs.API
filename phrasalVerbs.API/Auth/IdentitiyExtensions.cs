namespace PhrasalVerbs.API.Auth;

public static class IdentitiyExtensions
{
    public static Guid? GetUserId(this HttpContext context)
    {
        var userId = context.User.Claims.SingleOrDefault(x => x.Type == "userid");

        if(Guid.TryParse(userId?.Value, out var id))
            return id;

        return null;
    }
}
