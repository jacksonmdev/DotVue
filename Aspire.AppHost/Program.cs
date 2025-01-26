var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddPostgres("app-db")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.Web>("app-api")
    .WithReference(database)
    .WaitFor(database);

builder.Build().Run();
