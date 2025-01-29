using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
    private readonly IAuthorizationService _authorizationService;

    public UserService(UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _claimsFactory = claimsFactory;
        _authorizationService = authorizationService;
    }
    
    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user?.UserName;
    }
    
}