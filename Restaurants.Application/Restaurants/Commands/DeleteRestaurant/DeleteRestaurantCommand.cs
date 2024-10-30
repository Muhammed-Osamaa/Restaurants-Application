using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand : IRequest
{
    public int Id { get; init; }
}
