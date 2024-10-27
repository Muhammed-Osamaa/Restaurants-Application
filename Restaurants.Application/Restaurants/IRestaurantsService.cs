using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto?> GetRestaurantById(int id);
    }
}