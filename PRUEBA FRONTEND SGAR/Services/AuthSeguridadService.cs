using System.Net.Http.Json;
using PRUEBA_FRONTEND_SGAR.Models;

namespace PRUEBA_FRONTEND_SGAR.Services
{
    public class AuthSeguridadService
    {
        private readonly HttpClient _http;

        public AuthSeguridadService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string?> LoginAsync(CredencialesRequest credenciales)
        {
            try
            {
                // Llama al endpoint del backend de seguridad
                var response = await _http.PostAsJsonAsync("api/user/login", credenciales);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    return token.Trim('"'); // limpia comillas extra
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
