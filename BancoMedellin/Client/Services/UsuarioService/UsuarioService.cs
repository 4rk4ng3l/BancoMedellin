using System.Net.Http.Json;
using System.Net.Http.Headers;
namespace BancoMedellin.Client.Services.UsuarioService
{

    public class UsuarioService : IUsuarioService
    {
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public Usuario Usuario = new();
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public UsuarioService(HttpClient http, ILocalStorageService localStorageService)
        {
            _http = http;
            _localStorage = localStorageService;    
        }
        

        public async Task GetUsuarios()
        {
            try
            {
                Usuarios = await _http.GetFromJsonAsync<List<Usuario>>("api/usuario/getall");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task GetUsuarioById(ulong Dni)
        {
            Usuario = await _http.GetFromJsonAsync<Usuario>("api/Usuario/{Dni}");
        }

        public async Task Login(LoginDto usuario)
        {
            string Token = await _http.GetStringAsync("api/usuario/login");
        }
    }
}
