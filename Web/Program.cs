using Infrastructure.Persistence;
using Web;

var builder = WebApplication.CreateBuilder(args);
builder.InitializeWebServices();

var app = builder.Build();

await app.SeedDbAsync();

app.PostInitializeWebServices();
app.Run();
