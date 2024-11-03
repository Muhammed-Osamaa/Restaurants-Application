using MediatR;

namespace Restaurants.Application.Users.Commands.UpdateUserDetail;

public class UpdateUserDetailCommand : IRequest
{
    public DateOnly? DateOfBirth { get; init; }
    public string? Nationality { get; init; }
}
