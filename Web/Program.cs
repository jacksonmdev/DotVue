using Web;

var builder = WebApplication.CreateBuilder(args);
builder.InitializeWebServices();

var app = builder.Build();
app.PostInitializeWebServices();
app.Run();
