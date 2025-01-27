using NSwag;
using NSwag.Generation.Processors.Security;

namespace Web.Services;

public static class OpenApiService
{
    public static void SetOpenApi(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "DotVue API";
            
            // Add JWT
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });
    }
}