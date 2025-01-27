var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddPostgres("app-db")
    .WithDataVolume()
    .WithPgAdmin();

var api = builder.AddProject<Projects.Web>("app-api")
    .WithExternalHttpEndpoints()
    .WithReference(database)
    .WaitFor(database);

builder.AddNpmApp("app-vue", "../Web/VueApp")
    .WithReference(api)
    .WaitFor(api)
    .WithHttpEndpoint(targetPort: 4000, port: 8080)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
