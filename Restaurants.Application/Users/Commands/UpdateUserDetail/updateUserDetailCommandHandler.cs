using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands.UpdateUserDetail;

public class updateUserDetailCommandHandler(ILogger<updateUserDetailCommandHandler> logger,
    IUserContext userContext, IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailCommand>
{
    public async Task Handle(UpdateUserDetailCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser() ?? throw new InvalidOperationException("the Current user is invalid");

        logger.LogInformation("Updating a user with id: {userId}, with {@request}",user.Id , request);

        var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken) ?? throw new NotFoundException(nameof(User), user.Id);

        dbUser.Nationality = request.Nationality;
        dbUser.DateOfBirth = request.DateOfBirth;

        await userStore.UpdateAsync(dbUser,cancellationToken);

    }
}
