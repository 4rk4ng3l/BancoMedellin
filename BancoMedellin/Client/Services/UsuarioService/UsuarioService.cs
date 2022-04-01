using System.Net.Http.Json;
namespace BancoMedellin.Client.Services.UsuarioService
{

    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;
        public UsuarioService(HttpClient http)
        {
            _http = http;
        }
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public async Task GetUsuarios()
        {
            Usuarios = await _http.GetFromJsonAsync<List<Usuario>>("api/usuario/getallusuarios");
        }
    }
}
