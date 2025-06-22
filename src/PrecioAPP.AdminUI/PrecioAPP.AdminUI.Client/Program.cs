using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PrecioAPP.AdminUI.Client.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMediatrConfigs();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
