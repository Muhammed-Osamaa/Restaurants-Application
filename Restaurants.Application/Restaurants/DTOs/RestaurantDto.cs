using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivary { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }

    public List<DishDto> Dishes { get; set; } = [];

    //public static RestaurantDto? FromEntity(Restaurant? restaurant)
    //{
    //    if (restaurant == null) return null;
    //    return new()
    //    {
    //        Id = restaurant.Id,
    //        Name = restaurant.Name,
    //        Category = restaurant.Category,
    //        Description = restaurant.Description,
    //        HasDelivary = restaurant.HasDelivary,
    //        City = restaurant.Address?.City,
    //        PostalCode = restaurant.Address?.PostalCode,
    //        Street = restaurant.Address?.Street,
    //        Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList(),
    //    };
    //}
}
