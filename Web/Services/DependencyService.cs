using Application.Common.Interfaces;
using Web.Common;

namespace Web.Services;

public static class DependencyService
{
    public static void SetDependencies(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICurrentUser, CurrentUserService>();
    }
}