using Restaurants.API.Middlewares;
using Restaurants.API.RequestTimeLoggingMiddleware;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

builder.Host.UseSerilog((context, cfg) =>
{
    //cfg
    //.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
    //.MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
    //.WriteTo.Console(
    //    outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message:lj}{NewLine}{Exception}")
    //.WriteTo.File("Logs/Restaurant-API-.log" , rollingInterval:RollingInterval.Day , rollOnFileSizeLimit:true);
    cfg.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();


using var scope = app.Services.CreateScope();
var restaurants = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await restaurants.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<RequestTimeLoggingMiddleware>();

app.UseSerilogRequestLogging();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
