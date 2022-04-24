namespace BancoMedellin.Server.Services.CuentaService
{
    public interface ICuentaService
    {
        Task<List<Cuenta>> GetCuentasUsuario();
        Task<List<Autorizada>> GetCuentasAutorizadas();
    }
}
