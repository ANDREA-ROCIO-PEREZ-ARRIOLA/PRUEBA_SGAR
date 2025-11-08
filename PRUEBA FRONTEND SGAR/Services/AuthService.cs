using PRUEBA_FRONTEND_SGAR.Models;
using System.Net.Http.Json;

namespace PRUEBA_FRONTEND_SGAR.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string?> LoginAsync(CredencialesOrganizationRequest credenciales)
        {
            var response = await _http.PostAsJsonAsync("api/organization/login", credenciales);

            if (!response.IsSuccessStatusCode)
                return null;

            var token = await response.Content.ReadAsStringAsync();
            return token.Replace("\"", ""); // Elimina comillas del string
        }
    }
}
