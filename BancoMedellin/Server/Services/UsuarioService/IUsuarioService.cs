namespace BancoMedellin.Server.Services.UsuarioService

{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetUsuarioByDni(ulong Dni);
        Task<Usuario> Registrar(UsuarioDTO usuario);
        Task<string> Login(UsuarioDTO usuario);
        
    }
}
