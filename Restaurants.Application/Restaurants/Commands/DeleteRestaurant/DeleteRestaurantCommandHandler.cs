using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
     IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"A restaurant has been deleted with ID {request.Id}");
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
     
        await restaurantsRepository.DeleteAsync(restaurant);
       
    }
}
