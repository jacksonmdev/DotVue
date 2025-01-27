using Application;
using Carter;
using Infrastructure;
using Web.Services;

namespace Web;

public static class SetupDependency
{
    public static void InitializeWebServices(this IHostApplicationBuilder builder)
    {
        builder.AddServiceDefaults();
        builder.Services.AddCarter();

        // Add architecture services
        builder.AddApplicationServices();
        builder.AddInfrastructureServices();
        
        // Add services to the container.
        builder.SetAuth();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
    }

    public static void PostInitializeWebServices(this WebApplication app)
    {
        app.MapDefaultEndpoints();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.MapCarter();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}