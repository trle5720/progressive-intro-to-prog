var builder = DistributedApplication.CreateBuilder(args);

var postgresServer = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var broker = builder.AddNats("nats");

var linksDb = postgresServer.AddDatabase("links");

var linksApi = builder.AddProject<Projects.Links_Api>("links-api")
    .WithReference(linksDb)
    .WithReference(broker)
    .WaitFor(broker)
    .WaitFor(linksDb);

builder.Build().Run();
