using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishById;

public class GetDishByIdQueryHandler(ILogger<GetDishByIdQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository , IMapper mapper) : IRequestHandler<GetDishByIdQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get a dish with id : {Id} for Restaurant with id {restaurantId}",request.Id,request.RestaurantId);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId) 
            ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        var dish = restaurant.Dishes.FirstOrDefault(x => x.Id == request.Id) 
            ?? throw new NotFoundException(nameof(Dish), request.Id.ToString());
        return mapper.Map<DishDto>(dish); 
    }
}
