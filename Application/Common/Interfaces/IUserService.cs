﻿using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IUserService
{
    Task<string?> GetUserNameAsync(string userId);
    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> AuthorizeAsync(string userId, string policyName);
    Task<Result> DeleteUserAsync(string userId);
}