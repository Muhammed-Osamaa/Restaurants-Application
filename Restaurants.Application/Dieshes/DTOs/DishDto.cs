using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.DTOs;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; }

    public int? KiloCalories { get; set; }

    //public static DishDto FromEntity(Dish dish)
    //{
    //    return new()
    //    {
    //        Id = dish.Id,
    //        Name = dish.Name,
    //        Description = dish.Description,
    //        KiloCalories = dish.KiloCalories,
    //        Price = dish.Price,
    //    };
    //}
}
