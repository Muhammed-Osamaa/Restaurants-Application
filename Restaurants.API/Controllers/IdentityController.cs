using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commands.UpdateUserDetail;

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
}
