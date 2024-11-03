namespace Restaurants.Application.Users;

public record CurrentUser(string Id, string Email,IEnumerable<string> Role)
{
    public bool IsInRole(string role) => Role.Contains(role);
}   
