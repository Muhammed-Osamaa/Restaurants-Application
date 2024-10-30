using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
     IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("The restaurant is updated with Id {requestId} with {@request}",request.Id,request);
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        //restaurant.Name = request.Name;
        //restaurant.Description = request.Description;
        //restaurant.HasDelivary = request.HasDelivary;

        mapper.Map(request, restaurant);
        await restaurantsRepository.SaveChanges();
    
    }
}
