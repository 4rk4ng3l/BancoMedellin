namespace BancoMedellin.Server.Services.TransferenciaService
{
    public interface ITransferenciaService
    {
        Task<List<Transferencia>> GetTransferenciasByUser();
        Task<int> AddTransferencia(TransferenciaDto transferencia);
    }
}
