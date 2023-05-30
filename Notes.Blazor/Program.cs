using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Notes.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var defaultUri = new Uri(builder.HostEnvironment.BaseAddress);
var utmShopApiUri = new Uri("https://localhost:5001");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = utmShopApiUri
});
builder.Services.AddMudServices();

await builder.Build().RunAsync();
