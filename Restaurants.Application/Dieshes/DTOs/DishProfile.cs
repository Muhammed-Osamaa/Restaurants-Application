using AutoMapper;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dieshes.DTOs;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish,DishDto>();
    }
}
