namespace BancoMedellin.Server.Services.TransferenciaService
{
    public interface ITransferenciaService
    {
        Task<List<Transferencia>> GetTransferenciasByUser();
        Task<string> SaveTransferenciaPropia(TransferenciaDto transferencia);
        Task<string> SaveTransferenciaTercero(TransferenciaDto transferencia);
    }
}
