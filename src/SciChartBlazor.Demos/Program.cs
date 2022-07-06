using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SciChartBlazor;
using SciChartBlazor.Demos;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddUserSecrets<App>()
    .AddJsonFile("/wwwroot/appsettings.json",true)
    .Build();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddSciChart(options =>
{
    options.RuntimeLicenseKey = builder.Configuration["SciChart:LicenseKey"];
});

await builder.Build().RunAsync();
