using FirstBlazorApp.Client;
using FirstBlazorApp.Client.HttpRepository;
using FirstBlazorApp.Client.HttpRepository.Interface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44349/api/") });
builder.Services.AddScoped<IProductRepo, ProductRepo>();

await builder.Build().RunAsync();
