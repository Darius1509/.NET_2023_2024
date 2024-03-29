using Blazored.LocalStorage;
using ECommerceApp.App;
using ECommerceApp.App.Auth;
using ECommerceApp.App.Contracts;
using ECommerceApp.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<CustomStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7040/");
});
builder.Services.AddHttpClient<ICategoryDataService, CategoryDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7040/");
});
builder.Services.AddHttpClient<IAddressDataService, AddressDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7040/");
});
builder.Services.AddHttpClient<IProductDataService, ProductDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7040/");
});
builder.Services.AddHttpClient<IOrderDataService, OrderDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7040/");
});
builder.Services.AddMudServices();

await builder.Build().RunAsync();
