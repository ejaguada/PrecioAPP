var builder = DistributedApplication.CreateBuilder(args);


var identity = builder.AddProject<Projects.PrecioAPP_Identity>("precioapp-identity");

var api = builder.AddProject<Projects.PrecioAPP_Web>("web").WaitFor(identity);

builder.AddProject<Projects.PrecioAPP_AdminUI>("admin-ui")
    .WaitFor(identity)
    .WaitFor(api);

builder.Build().Run();
