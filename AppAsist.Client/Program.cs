using AppAsist.Client;
using AppAsist.Client.Servicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proyecto2024.Client.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configurar el componente ra�z
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar el HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registrar IHttpServicio con su implementaci�n HttpServicio
builder.Services.AddScoped<IHttpServicio, HttpServicio>();

// Construir y ejecutar la aplicaci�n
await builder.Build().RunAsync();
