using System.Security.Claims;

namespace BancoMedellin.Server.Services.TransferenciaService
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public TransferenciaService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccesor = httpContextAccessor;
            ;
        }

        public async Task<string> AddTransferencia(TransferenciaDto transferenciaDto)
        {
            try
            {

                int usuarioDni;
                if (_httpContextAccesor.HttpContext != null)
                {
                    using (var dbContextTransaction = _context.Database.BeginTransaction())
                    {
                        usuarioDni = Convert.ToInt32(_httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

                        Transferencia transferencia = new();
                        transferencia.UsuarioDni = usuarioDni;
                        transferencia.CuentaCredito = transferenciaDto.CuentaCredito;
                        transferencia.CuentaDebito = transferenciaDto.CuentaDebito;
                        transferencia.Valor = transferenciaDto.Valor;

                        await _context.Transferencias.AddAsync(transferencia);

                        var cuentaCredito = await _context.Cuentas.Where(c => c.Id == transferenciaDto.CuentaCredito).FirstOrDefaultAsync();
                        if (cuentaCredito.Balance - transferenciaDto.Valor >= 0)
                        {
                            cuentaCredito.Balance = cuentaCredito.Balance - transferenciaDto.Valor;
                        }

                        var cuentaDebito = await _context.Cuentas.Where(c => c.Id == transferenciaDto.CuentaDebito).FirstOrDefaultAsync();
                        cuentaDebito.Balance = cuentaDebito.Balance + transferenciaDto.Valor;

                        await _context.SaveChangesAsync();

                        dbContextTransaction.Commit();
                        return "Ok";
                    }
                }
                else
                {
                    return "Usuario no autenticado";
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Transferencia>> GetTransferenciasByUser()
        {
            int usuarioDni;
            if (_httpContextAccesor.HttpContext != null)
            {
                usuarioDni = Convert.ToInt32(_httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var transferencias = await _context.Transferencias.Where(t => t.UsuarioDni == usuarioDni).ToListAsync();
                return transferencias;
            }
            else
            {
                return new List<Transferencia>();
            }

        }
    }
}
