var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddPostgres("app-db")
    .WithDataVolume()
    .WithPgAdmin()
    .AddDatabase("DotVueDB");

var api = builder.AddProject<Projects.Web>("app-api")
    .WithExternalHttpEndpoints()
    .WithReference(database)
    .WithEnvironment("ConnectionStrings__DotVueDb", "Host=localhost;Database=dotvue_db;Username=postgres;Password=h5mAwV3SAsdAFyac;Include Error Detail=true;") //Comment this out to use DB inside Aspire
    .WaitFor(database);

builder.AddNpmApp("app-vue", "../Web/VueApp")
    .WithReference(api)
    .WaitFor(api)
    .WithHttpEndpoint(targetPort: 4000, port: 8080)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
