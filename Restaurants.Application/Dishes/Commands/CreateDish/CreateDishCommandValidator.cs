using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish => dish.Price).GreaterThanOrEqualTo(1).WithMessage("The Price Can't Less or Equal than 0");
        RuleFor(dish => dish.KiloCalories).GreaterThanOrEqualTo(1).WithMessage("The Price Can't Less or Equal than 0");
    }
}
