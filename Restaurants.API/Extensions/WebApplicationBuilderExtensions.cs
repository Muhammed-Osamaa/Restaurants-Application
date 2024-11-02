using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;

using Serilog;

namespace Restaurants.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen(cgf =>
        {
            cgf.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            cgf.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference() { Type = ReferenceType.SecurityScheme , Id = "bearerAuth"}
            },
            []
        }
    });
        });

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
    }
}
