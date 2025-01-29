var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddPostgres("app-db")
    .WithDataVolume()
    .WithPgAdmin()
    .AddDatabase("DotVueDB");
    // .WithEnvironment("POSTGRES_USER", "postgres") // Set the PostgreSQL user
    // .WithEnvironment("POSTGRES_PASSWORD", "slump6Fluent6sal!va") // Set the PostgreSQL password
    // .WithEnvironment("POSTGRES_DB", "postgres");
    // .WithHttpEndpoint(targetPort: 5432, port: 5400)
    // .WithExternalHttpEndpoints();

var api = builder.AddProject<Projects.Web>("app-api")
    .WithExternalHttpEndpoints()
    .WithReference(database)
    // .WithEnvironment("dotnetvue_db", "Host=app-db;Database=dotvue_db;Username=postgres;Password=h5mAwV3SAsdAFyac;Include Error Detail=true;")
    .WaitFor(database);

builder.AddNpmApp("app-vue", "../Web/VueApp")
    .WithReference(api)
    .WaitFor(api)
    .WithHttpEndpoint(targetPort: 4000, port: 8080)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
