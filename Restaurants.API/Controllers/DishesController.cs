using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDishes;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Application.Dishes.Queries.GetAllDishes;
using Restaurants.Application.Dishes.Queries.GetDishById;
using Restaurants.Infrastructure.Authorization;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/[controller]")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateDish([FromRoute]int restaurantId , CreateDishCommand createDishCommand)
        {
            createDishCommand.RestaurantId = restaurantId;
            var id = await mediator.Send(createDishCommand);
            return CreatedAtAction(nameof(GetDishById), new {restaurantId, id} , null);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = PolicyNames.AtLeast20)]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishes([FromRoute]int restaurantId)
        {
           var dishes =  await mediator.Send(new GetAllDishesQuery() { RestaurantId = restaurantId});
           return Ok(dishes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DishDto>> GetDishById([FromRoute]int restaurantId , [FromRoute]int id)
        {
            var dish = await mediator.Send(new GetDishByIdQuery() { Id = id , RestaurantId = restaurantId});
            return Ok(dish);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete()]
        public async Task<IActionResult> DeleteDishes([FromRoute]int restaurantId)
        {
            await mediator.Send(new DeleteDishesCommand(){ RestaurantId = restaurantId });
            return NoContent();
        }
    }
}
