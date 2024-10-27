using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, 
    ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Get All Restaurants");
        var restaurants =  await restaurantsRepository.GetAllAsync();
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDto;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation("Get a Restaurants");
        var restaurant = await restaurantsRepository.GetByIdAsync(id); 
        return mapper.Map<RestaurantDto?>(restaurant);
    }
}
