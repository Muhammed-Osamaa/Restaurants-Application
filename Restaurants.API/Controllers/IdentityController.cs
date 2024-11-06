using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Application.Users.Commands.UnAssignUserRole;
using Restaurants.Application.Users.Commands.UpdateUserDetail;
using Restaurants.Domain.Constant;

namespace Restaurants.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPatch("user")]
    public async Task<IActionResult> UpdateUser(UpdateUserDetailCommand updateUserDetailCommand)
    {
        await mediator.Send(updateUserDetailCommand);

        return NoContent();
    }

    [Authorize(Roles = UserRole.Admin)]
    [HttpPost("userRole")]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand assignUserRoleCommand)
    {
        await mediator.Send(assignUserRoleCommand);

        return NoContent();
    }

    [Authorize(Roles = UserRole.Admin)]
    [HttpDelete("userRole")]
    public async Task<IActionResult> UnAssignUserRole(UnAssignUserRoleCommand unAssignUserRoleCommand)
    {
        await mediator.Send(unAssignUserRoleCommand);

        return NoContent();
    }
}
