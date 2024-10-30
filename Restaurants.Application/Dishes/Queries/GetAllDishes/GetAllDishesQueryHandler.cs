using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes;

public class GetAllDishesQueryHandler(ILogger<GetAllDishesQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository , IMapper mapper) : IRequestHandler<GetAllDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get All Dishes for Restaurant with id : {RestuarandId}", request.RestaurantId);
        var restaurants = await restaurantsRepository.GetByIdAsync(request.RestaurantId)
            ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        return mapper.Map<IEnumerable<DishDto>>(restaurants.Dishes);

    }
}
