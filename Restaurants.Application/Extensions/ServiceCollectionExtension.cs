using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var AppAssembly = typeof(ServiceCollectionExtension).Assembly;
            services.AddScoped<IRestaurantsService , RestaurantsService>();
            services.AddAutoMapper(AppAssembly);
            services.AddValidatorsFromAssembly(AppAssembly).AddFluentValidationAutoValidation();
        }
    }
}
