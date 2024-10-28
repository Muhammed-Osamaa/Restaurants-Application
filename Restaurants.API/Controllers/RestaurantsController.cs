using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantsById([FromRoute]int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery() { Id = id});
            if (restaurant == null) return NotFound("Can't Find this Id");
            return Ok(restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute]int id)
        {
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand() { Id = id});
            if (isDeleted) return NoContent();
            return NotFound("The id is invalid");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand createRestaurantCommand)
        {
            var id = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(GetRestaurantsById), new {id} , null);
        }

    }
}
