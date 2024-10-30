using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
{
    public async Task<int> CreateAsync(Dish entity)
    {
        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
