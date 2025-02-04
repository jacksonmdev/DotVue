using System.Text.Json.Serialization;
using Infrastructure.Persistence;
using Web;

var builder = WebApplication.CreateBuilder(args);
builder.InitializeWebServices();

// Strictly Enforce int Type on payloads
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
});

var app = builder.Build();

// await app.SeedDbAsync();

app.PostInitializeWebServices();
app.Run();
