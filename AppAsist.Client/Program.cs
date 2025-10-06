using AppAsist.Client;
using AppAsist.Client.Autorizacion;
using AppAsist.Client.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configurar el componente ra�z
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar el HttpClient
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();

// Registrar IHttpServicio con su implementaci�n HttpServicio
builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddScoped<ProveedorAutenticacionJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionJWT>(proveedor =>
    proveedor.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<ILoginService, ProveedorAutenticacionJWT>(proveedor =>
    proveedor.GetRequiredService<ProveedorAutenticacionJWT>());
// Construir y ejecutar la aplicaci�n
await builder.Build().RunAsync();
