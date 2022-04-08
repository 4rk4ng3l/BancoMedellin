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
        public Usuario Usuario = new Usuario();
        
        public async Task GetUsuarios()
        {
            Usuarios = await _http.GetFromJsonAsync<List<Usuario>>("Api/Usuario/GetAll");
        }

        public async Task GetUsuarioById(ulong Dni)
        {
            Usuario = await _http.GetFromJsonAsync<Usuario>("api/usuario/{Dni}");
        }
    }
}
