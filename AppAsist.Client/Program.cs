using AppAsist.Client;
using AppAsist.Client.Autorizacion;
using AppAsist.Client.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proyecto2024.Client.Servicios;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configurar el componente raíz
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar el HttpClient
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();

// Registrar IHttpServicio con su implementación HttpServicio
builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacion>();
// Construir y ejecutar la aplicación
await builder.Build().RunAsync();
