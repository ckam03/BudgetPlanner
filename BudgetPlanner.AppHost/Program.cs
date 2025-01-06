var builder = DistributedApplication.CreateBuilder(args);

var postgresQL = builder
    .AddPostgres("postgresQL")
    .WithImage("ankane/pgvector")
    .WithImageTag("latest")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithPgWeb();

var postgres = postgresQL.AddDatabase("postgres");

builder.AddProject<Projects.BudgetPlanner_API>("api").WithReference(postgres).WaitFor(postgres);

builder.Build().Run();
