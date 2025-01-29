namespace Web.Services;

public static class CorsService
{
    public static void SetCors(this IHostApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CORS",
                b =>
                {
                    b.SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithOrigins("http://localhost:4000", "http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
    }
}