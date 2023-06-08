using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Notes.Blazor;
using Notes.Blazor.Services.Implementations;
using Notes.Blazor.Services.Interfaces;

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

builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteTagRepository, NoteTagRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<DateStateService>();

await builder.Build().RunAsync();
