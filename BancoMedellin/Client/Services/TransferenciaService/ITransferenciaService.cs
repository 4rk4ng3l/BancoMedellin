namespace BancoMedellin.Client.Services.TransferenciaService
{
    public interface ITransferenciaService
    {
        Transferencia Transferencia { get; set; }
        Task GetCuentasPropias();
        Task GetCuentasAutorizadas();
        Task SaveTransferencia(TransferenciaDto transferenciaDto);
    }
}
