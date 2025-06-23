using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.Extensions.Configuration;
using PrecioAPP.AdminUI.Components;
using PrecioAPP.AdminUI.Services;
using static System.Net.WebRequestMethods;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddMudServices();

builder.Services.AddScoped<LogOutService>();

var configuration = builder.Configuration;

var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

// Add Authentication services
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
  options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(options => options.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
.AddOpenIdConnect(options =>
{
  options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  options.Authority = "https://localhost:7126";
  options.SignedOutRedirectUri = "https://localhost:7091";
  options.ClientId = "webapp_admin";
  options.ClientSecret = "secret";
  options.ResponseType = "code";
  options.SaveTokens = true;
  options.GetClaimsFromUserInfoEndpoint = true;
  options.RequireHttpsMetadata = false;
  options.Scope.Add("openid");
  options.Scope.Add("profile");
  options.Scope.Add("api1.read");
});

// Blazor auth services
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddCascadingAuthenticationState();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
