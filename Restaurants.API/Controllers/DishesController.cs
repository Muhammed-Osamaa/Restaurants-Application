using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Application.Dishes.Queries.GetAllDishes;
using Restaurants.Application.Dishes.Queries.GetDishById;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurant/{restaurantId}/[controller]")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute]int restaurantId , CreateDishCommand createDishCommand)
        {
            createDishCommand.RestaurantId = restaurantId;
            await mediator.Send(createDishCommand);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishes([FromRoute]int restaurantId)
        {
           var dishes =  await mediator.Send(new GetAllDishesQuery() { RestaurantId = restaurantId});
           return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishDto>> GetDisheById([FromRoute]int restaurantId , [FromRoute]int id)
        {
            var dish = await mediator.Send(new GetDishByIdQuery() { Id = id , RestaurantId = restaurantId});
            return Ok(dish);
        }
    }
}
