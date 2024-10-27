using Restaurants.Application.Extensions;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();


var app = builder.Build();

using var scope = app.Services.CreateScope();
var restaurants = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await restaurants.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
