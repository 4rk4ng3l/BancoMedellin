using System.Security.Claims;

namespace BancoMedellin.Server.Services.TransferenciaService
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly int _usuarioDni;
        public TransferenciaService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccesor = httpContextAccessor;
            _usuarioDni = Convert.ToInt32(_httpContextAccesor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public async Task<int> AddTransferencia(TransferenciaDto transferenciaDto)
        {
            try
            {

                if (_httpContextAccesor.HttpContext != null)
                {
                    using (var dbContextTransaction = _context.Database.BeginTransaction())
                    {

                        //Validamos que la cuenta Origen le pertenezca al usuario
                        var cuentaUsuario = await _context.Cuentas.Where(c => c.Id == transferenciaDto.CuentaCredito).FirstOrDefaultAsync();
                        
                        if (cuentaUsuario is not null && _usuarioDni == cuentaUsuario.UsuarioDni)
                        {

                            Transferencia transferencia = new();
                            transferencia.UsuarioDni = _usuarioDni;
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
                            return transferencia.Id;
                        }
                        else
                        {
                            return "Cuenta Origen no pertenece al usuario!.";
                        }
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
