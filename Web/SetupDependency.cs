using Application;
// using Carter;
using Infrastructure;
using Web.Common;
using Web.Services;

namespace Web;

public static class SetupDependency
{
    public static void InitializeWebServices(this IHostApplicationBuilder builder)
    {
        builder.AddServiceDefaults();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddEndpointsApiExplorer();

        // Add architecture services
        builder.AddApplicationServices();
        // REMOVE LATER WIP
        // builder.AddInfrastructureServices();
        
        // Add services to the container.
        builder.SetCors();
        builder.SetAuth();
        builder.SetOpenApi();
        builder.SetDependencies();
    }

    public static void PostInitializeWebServices(this WebApplication app)
    {
        // if (app.Environment.IsDevelopment())
        // {
        //
        // }
        
        app.UseSwaggerUi(settings =>
        {
            settings.Path = "/api";
            settings.DocumentPath = "/api/specification.json";
            settings.DocumentTitle = "DotVue API Explorer";
        });
            
        app.MapDefaultEndpoints();
        
        app.MapEndpoints();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors("CORS");
        app.UseAuthentication();
        app.UseAuthorization();
    }
}