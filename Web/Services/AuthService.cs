using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Web.Services;

public static class AuthService
{
    public static void SetAuth(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();
        
        builder.Services.AddAuthorization();
    }
}