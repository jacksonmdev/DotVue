namespace Application.Common.Interfaces;

public interface IUserService
{
    Task<string?> GetUserNameAsync(string userId);
}