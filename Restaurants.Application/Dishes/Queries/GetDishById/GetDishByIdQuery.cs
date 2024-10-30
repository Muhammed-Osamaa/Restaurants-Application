using MediatR;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQuery : IRequest<DishDto>
{
    public int Id { get; init; }
    public int RestaurantId { get; set; }
}
