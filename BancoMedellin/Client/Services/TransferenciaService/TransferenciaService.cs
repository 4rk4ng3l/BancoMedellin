using System.Net.Http.Json;
namespace BancoMedellin.Client.Services.TransferenciaService
{
    public class TransferenciaService : ITransferenciaService
    {
        public Transferencia Transferencia { get; set; } = new Transferencia();
        public List<Cuenta> cuentasPropias = new List<Cuenta>();
        public List<Cuenta> cuentasAutorizadas = new List<Cuenta>();

        public TransferenciaService(HttpClient http)
        {
            
        }
        public Task GetCuentasAutorizadas()
        {
            throw new NotImplementedException();
        }

        public Task GetCuentasPropias()
        {
            throw new NotImplementedException();
        }

        public Task SaveTransferencia(TransferenciaDto transferenciaDto)
        {
            throw new NotImplementedException();
        }
    }
}
