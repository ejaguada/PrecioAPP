﻿using ApuntecaDigital.Backend.Web.Configurations;
using PrecioAPP.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthServices();

builder.Services.AddControllers(); // ControllersWithView if you need Views


var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

builder.AddLoggerConfigs();

var appLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.AddOptionConfigs(builder.Configuration, appLogger, builder);
builder.Services.AddServiceConfigs(appLogger, builder);

builder.Services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                  o.ShortSchemaNames = true;
                });

builder.AddServiceDefaults();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
await app.UseAppMiddlewareAndSeedDatabase();
app.MapControllers();

app.Run();

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program { }
