using Microsoft.AspNetCore.Authorization;

namespace Restaurants.Infrastructure.Authorization;

public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public int MinimumAge { get; init; }
}

