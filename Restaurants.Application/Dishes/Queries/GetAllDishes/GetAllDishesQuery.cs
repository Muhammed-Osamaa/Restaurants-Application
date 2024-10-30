using MediatR;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishesQuery : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; init; }
}
