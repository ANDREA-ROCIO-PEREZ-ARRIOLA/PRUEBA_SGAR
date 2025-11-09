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

// CONEXIÓN DE LA API DE NAVEGACIÓN
builder.Services.AddHttpClient("NavigationAPI", client =>
{
    client.BaseAddress = new Uri("https://sgar-navigation.vercel.app/");
});

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Servicio de autenticación
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<MunicipioService>();
builder.Services.AddScoped<AuthSeguridadService>();


await builder.Build().RunAsync();
