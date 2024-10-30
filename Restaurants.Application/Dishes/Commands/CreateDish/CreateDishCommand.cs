using MediatR;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommand : IRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; }

    public int? KiloCalories { get; set; }

    public int RestaurantId { get; set; }
}
