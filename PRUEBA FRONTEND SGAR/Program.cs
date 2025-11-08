using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PRUEBA_FRONTEND_SGAR;
using PRUEBA_FRONTEND_SGAR.Services; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//CONEXIÓN DE LA API SEGURIDAD
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://sgarseguridad.somee.com/") //API SEGURIDAD
});

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Servicio de autenticación
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
