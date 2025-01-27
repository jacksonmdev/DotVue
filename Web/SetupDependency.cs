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
        builder.Services.AddEndpointsApiExplorer();

        // Add architecture services
        builder.AddApplicationServices();
        builder.AddInfrastructureServices();
        
        // Add services to the container.
        builder.SetCors();
        builder.SetAuth();
        builder.SetOpenApi();
    }

    public static void PostInitializeWebServices(this WebApplication app)
    {
        app.UseSwaggerUi(settings =>
        {
            settings.Path = "/api";
            settings.DocumentPath = "/api/specification.json";
            settings.DocumentTitle = "DotVue API Explorer";
        });
        
        app.MapDefaultEndpoints();
        app.MapCarter();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}