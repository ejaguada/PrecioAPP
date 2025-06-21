var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PrecioAPP_Web>("web");

builder.Build().Run();
