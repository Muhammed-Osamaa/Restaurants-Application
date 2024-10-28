using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand : IRequest<bool>
{
    public int Id { get; init; }
}
