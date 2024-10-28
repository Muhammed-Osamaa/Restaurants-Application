
using FluentValidation;


namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> _validCategory = ["Egyptian", "Italian", "American"];
    public CreateRestaurantCommandValidator()
    {
        //RuleFor(dto => dto.Name).NotEmpty().Length(4,20);

        //RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description field is required. ");

        //RuleFor(dto => dto.Category).NotEmpty().WithMessage("Category field is required. ");

        RuleFor(dto => dto.ContactEmail).EmailAddress();

        RuleFor(dto => dto.ContactNumber).Matches(@"^\+20(10|11|12|15)\d{8}$");

        RuleFor(dto => dto.Category).Must(_validCategory.Contains);

    }
}
