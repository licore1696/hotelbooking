using HotelBooking.Services.Contracts;
using HotelBooking.Web;
using HotelBooking.Web.Requests;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<IUserService, ApiUserService>();

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7256") 
});
builder.Services.AddMudServices();

await builder.Build().RunAsync();
