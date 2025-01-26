var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Web>("web-api");

builder.Build().Run();
