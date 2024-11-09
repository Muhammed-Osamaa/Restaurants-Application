using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Constant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interfaces;

namespace Restaurants.Infrastructure.Authorization.Services;

public class RestaurantAuthorizationService(ILogger<RestaurantAuthorizationService> logger,
    IUserContext userContext) : IRestaurantAuthorizationService
{
    public bool Authorize(Restaurant restaurant, ResourceOperation operation)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("Authorizing User {Email} to {operate} for restaurant {restaurantName}", currentUser?.Email, operation, restaurant.Name);

        if (operation == ResourceOperation.Create || operation == ResourceOperation.Read)
        {
            logger.LogInformation("Create/Read operation - successful authorization");
            return true;
        }

        if (operation == ResourceOperation.Delete && currentUser!.IsInRole(UserRole.Admin))
        {
            logger.LogInformation("Admin user delete operation - successful authorization");
            return true;
        }

        if (operation == ResourceOperation.Delete || operation == ResourceOperation.Update && currentUser!.Id == restaurant.OwnerId)
        {
            logger.LogInformation("Restaurant owner Delete/Update operation - successful authorization");
            return true;
        }

        return false;
    }
}
