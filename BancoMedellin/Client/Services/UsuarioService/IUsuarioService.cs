namespace BancoMedellin.Client.Services.UsuarioService
{
    public interface IUsuarioService
    {
        List<Usuario> Usuarios { get; set; }
        Task GetUsuarios();
        Task GetUsuarioById(ulong Dni);
    }
}
