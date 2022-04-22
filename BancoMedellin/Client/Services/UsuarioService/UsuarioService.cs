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
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "api/usuario/getall");
                var token = await _localStorage.GetItemAsStringAsync("token");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);
                //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _http.SendAsync(requestMessage);
                var responseStatusCode = response.StatusCode;

                if(responseStatusCode.ToString() == "OK")
                {
                    Usuarios = await response.Content.ReadFromJsonAsync<List<Usuario>>();
                }

                //_http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //Usuarios = await _http.GetFromJsonAsync<List<Usuario>>("api/usuario/getall");
            }catch (Exception ex)
            {
                throw;
            }
        }

        public async Task GetUsuarioById(ulong Dni)
        {
            Usuario = await _http.GetFromJsonAsync<Usuario>("api/Usuario/{Dni}");
        }

        public async Task Login(UsuarioDTO usuario)
        {
            string Token = await _http.GetStringAsync("api/usuario/login");
        }

       
    }
}
