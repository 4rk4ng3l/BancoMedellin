namespace BancoMedellin.Server.Services.UsuarioService

{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetUsuarioByDni(int Dni);
        Task<Usuario> Registrar(LoginDto usuario);
        Task<string> Login(LoginDto usuario);
    }
}
