using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper , IRestaurantsRepository restaurantsRepository, IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
  
        logger.LogInformation("{Email} with id: {UserId} is Creating a new Restaurant With {@request}",currentUser?.Email,currentUser?.Id,request);
        
        var restaurant = mapper.Map<Restaurant>(request);

        restaurant.OwnerId = currentUser.Id;
        
        return await restaurantsRepository.CreateAsync(restaurant);
    }
}
