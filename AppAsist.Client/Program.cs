using AppAsist.Client;
using AppAsist.Client.Servicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proyecto2024.Client.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Agregar el componente ra�z de la aplicaci�n
builder.RootComponents.Add<App>("#app");

// Registrar el HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registrar IHttpServicio con su implementaci�n HttpServicio
builder.Services.AddScoped<IHttpServicio, HttpServicio>();

// Construir y ejecutar la aplicaci�n
await builder.Build().RunAsync();
