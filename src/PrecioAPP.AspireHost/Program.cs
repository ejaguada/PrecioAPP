var builder = DistributedApplication.CreateBuilder(args);


var identity = builder.AddProject<Projects.PrecioAPP_Identity>("precioapp-identity");

builder.AddProject<Projects.PrecioAPP_Web>("web").WaitFor(identity);


builder.Build().Run();
