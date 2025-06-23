using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var launchProfileName = ShouldUseHttpForEndpoints() ? "http" : "https";

var identity = builder.AddProject<Projects.PrecioAPP_Identity>("identity", launchProfileName);

var webApp = builder.AddProject<Projects.PrecioAPP_AdminUI>("adminui", launchProfileName)
  .WithEnvironment("IdentityUrl", identity.GetEndpoint(launchProfileName));

var api = builder.AddProject<Projects.PrecioAPP_Web>("api");

webApp.WithEnvironment("CallBackUrl", webApp.GetEndpoint(launchProfileName));

builder.AddProject<Projects.PrecioAPP_AdminUI>("precioapp-adminui");

builder.Build().Run();



// For test use only.
// Looks for an environment variable that forces the use of HTTP for all the endpoints. We
// are doing this for ease of running the Playwright tests in CI.
static bool ShouldUseHttpForEndpoints()
{
  const string EnvVarName = "PRECIOAPP_USE_HTTP_ENDPOINTS";
  var envValue = Environment.GetEnvironmentVariable(EnvVarName);

  // Attempt to parse the environment variable value; return true if it's exactly "1".
  return int.TryParse(envValue, out int result) && result == 1;
}
