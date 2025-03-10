using System.IdentityModel.Tokens.Jwt;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Hangfire;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    private readonly IConfiguration _configuration;
    private HttpContext? httpContext { get; set; }

    public HangfireAuthorizationFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public bool Authorize(DashboardContext context)
    {
        httpContext = context.GetHttpContext();
        string? jwtToken;
        if (httpContext.Request.Query.ContainsKey("jwt_token"))
        {
            jwtToken = httpContext.Request.Query["jwt_token"].FirstOrDefault();
            if (!string.IsNullOrEmpty(jwtToken))
            {
                SetCookie(jwtToken);
            }
        }
        else
        {
            jwtToken = httpContext.Request.Cookies["_hangfireCookie"];
        }

        if (String.IsNullOrEmpty(jwtToken))
        {
            return false;
        }

        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(jwtToken);

        try
        {
            var emails = jwtSecurityToken.Claims.Where(t => t.Type == "email").ToList();
            var users = _configuration["Hangfire:AllowedUsers"]?.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            
            return users != null && users.Any(r => emails.Any(e => e.Value == r));
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    
    private void SetCookie(string jwtToken)
    {
        httpContext?.Response.Cookies.Append("_hangfireCookie",
            jwtToken,
            new CookieOptions() {Expires = DateTime.Now.AddMinutes(30)});
    }
}
