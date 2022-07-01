using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SciChartBlazor;
using SciChartBlazor.Demos;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddSciChart(options =>
{
    options.RuntimeLicenseKey = 
"dJN+hTB6etTv4a0Fyd3KkqXivCRW4jY24vIYWDs13D4/zkMI4AJjPo5pieoWRSdOWJ5xSU2rNhvNdhyuz" +
"TR9952mNcf668An1actK72/XP5Lf86OiK2PCtak73v03YmtVwMyWAsJh8ngfobL1XhDeyAnUIjs61qHb9N6" +
"/r7Aj2as4mxg+TOm4jRRyFq11gG9Kgs5oIajdtQ75WRO8//bYJrfesPtugSuCfWyzaHY5JY52IT7PjmmyEYL5" +
"xjCI4EPynarfbQw08VgnmaJSrYCYwinnQ6oTvaT5+dT3rqtSzyL5ZXcNikW1+KCymp8XX0rKIJktgdAGwzz6Gk" +
"iKb71tH8WRF/0fbmuO24u2G33beYLvDDFf8n4ZBmRUWeZL7e/YmYuoV6lXQ5yQQPTtCJbVZjqT/+j0yF7DZry" +
"ShWWu96ARjfz1A4Lk47ldDsxwoZU5yaSMM1pEadiAY2mUUG9Lp+0lFRBVdanbR9p0cz71Rl3+Tk+8EIb4CZxKR" +
"Z0TH0mhvYCjvW1uhXtw35GPs+kEZs17xf8M4m/Vnh+2CzUlzL0YgRxtRlsIZfNpGSmDQ7PGutPiBe0vGCvdc93" +
"fhB4sfkUQbzWYzpQGu/Os/YOxlGkEGsNTCY4eRmcKbN9V0ef8EBtOQjrw8cqsiyegX6Sx30KJYUxg/dbpUl2HO" +
"VSl0fNPjtdzLKutMwMKkjGda7KfGM3PNz0FTWn5Yx5BaoMXZ1leva8CZZ5fSQjqk6spl6NFyLE3hau/1n7Y0ds" +
"nZu8fCH16Zd1e6hOM2vxSD1Fy7vRRNiyIeqoFzqv/krsl+5IgBkYEE+m4m817BR/fWky+EaVlEe7rkC9";
});

await builder.Build().RunAsync();
