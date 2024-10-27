using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(s => s.Address == null ? null : s.Address.City))
            .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Address == null ? null : s.Address.Street))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(s => s.Address == null ? null : s.Address.PostalCode))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(s => s.Dishes));

        CreateMap<CreateRestaurantDto, Restaurant>()
           .ForMember(d => d.Address, opt => opt.MapFrom(s => new Address()
           { City = s.City, PostalCode = s.PostalCode, Street = s.Street }));

    }

}
