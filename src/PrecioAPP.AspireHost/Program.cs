var builder = DistributedApplication.CreateBuilder(args);


var identity = builder.AddProject<Projects.PrecioAPP_Identity>("precioapp-identity");

var api = builder.AddProject<Projects.PrecioAPP_Web>("web").WaitFor(identity);

builder.Build().Run();
