using System.Reflection;

namespace Web.Common;

public static class RouteMapExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, RouteBase group)
    {
        var groupName = group.GetType().Name;

        return app
            .MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName);
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(RouteBase);

        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is RouteBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}