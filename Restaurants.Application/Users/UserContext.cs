﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.Users;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User
            ?? throw new InvalidOperationException("User context is not present");

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        var userEmail = user.FindFirst(x => x.Type == ClaimTypes.Email)!.Value;
        var userRole = user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
        var nationality = user.FindFirst(x => x.Type == "Nationality")?.Value;
        var dateOfBirthString = user.FindFirst(x => x.Type == "DateOfBirth")?.Value;
        var dateOfBirth = dateOfBirthString is null
            ? (DateOnly?)null 
            : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd");
        return new CurrentUser(userId, userEmail, userRole,nationality,dateOfBirth);
    }
}
