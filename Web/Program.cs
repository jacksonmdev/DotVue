using System.Text.Json.Serialization;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Web;

var builder = WebApplication.CreateBuilder(args);

// Setup Azure App Configuration
var endpoint = builder.Configuration.GetConnectionString("AppConfiguration");
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options
        .Connect(endpoint)
        .ConfigureRefresh(refreshOptions =>
        {
            refreshOptions.Register("Sentinel", refreshAll: true);
        })
        .Select(KeyFilter.Any)
        .Select(KeyFilter.Any,  builder.Environment.EnvironmentName);
});

// Strictly Enforce int Type on payloads
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
});

builder.InitializeWebServices();

var app = builder.Build();

app.PostInitializeWebServices();

await app.SeedDbAsync();

app.Run();
