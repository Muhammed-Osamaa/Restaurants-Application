using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

internal class RestaurantsDbContext(DbContextOptions options) : IdentityDbContext<User>(options) 
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Restaurants.Domain.Entities.Restaurant>()
            .OwnsOne(x => x.Address);

    //    modelBuilder.Entity<Restaurants.Domain.Entities.Restaurants>()
    //        .HasMany(x => x.Dishes)
    //        .WithOne()
    //        .HasForeignKey(x => x.RestaurantsId);
    }
}
