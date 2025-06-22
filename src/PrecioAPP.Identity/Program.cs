using ApuntecaDigital.Backend.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer(options =>
{
  options.Events.RaiseErrorEvents = true;
  options.Events.RaiseInformationEvents = true;
  options.Events.RaiseFailureEvents = true;
  options.Events.RaiseSuccessEvents = true;
  options.EmitIssuerIdentificationResponseParameter = true;
})
  .AddInMemoryIdentityResources(Config.IdentityResources)
  .AddInMemoryApiScopes(Config.ApiScopes)
  .AddInMemoryApiResources(Config.ApiResources)
  .AddInMemoryClients(Config.Clients(builder.Configuration))
  .AddTestUsers(Config.Users)
  .AddDeveloperSigningCredential();

builder.Services.AddAuthorization();



builder.AddServiceDefaults();
var app = builder.Build();
app.MapDefaultEndpoints();

app.UseStaticFiles();

app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();
