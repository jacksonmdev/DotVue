using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class DbContextSeederExtension
{
    public static async Task SeedDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<ApplicationDbContextSeeder>();

        await seeder.InitializeContext();
        // await seeder.SeedDefaults(); //Run this after seeder.InitializeContext()
    }
}