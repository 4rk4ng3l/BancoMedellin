namespace BancoMedellin.Server.Services.UsuarioService

{
    public interface IUsuarioService
    {
       Task<List<Usuario>> GetAll();
       Task<Usuario> GetById(ulong Dni);
    }
}
