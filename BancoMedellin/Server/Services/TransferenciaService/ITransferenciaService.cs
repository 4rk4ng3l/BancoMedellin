namespace BancoMedellin.Server.Services.TransferenciaService
{
    public interface ITransferenciaService
    {
        Task<List<Transferencia>> GetTransferenciasByUser();
        Task<string> AddTransferencia(TransferenciaDto transferencia);
    }
}
