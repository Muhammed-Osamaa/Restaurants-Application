using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes;

public class DeleteDishesCommand : IRequest
{
    public int RestaurantId { get; set; }
}
