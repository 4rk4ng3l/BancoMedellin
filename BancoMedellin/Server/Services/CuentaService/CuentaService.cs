using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BancoMedellin.Server.Services.CuentaService
{
    public class CuentaService : ICuentaService
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly DataContext _context;
        public CuentaService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccesor = httpContextAccessor;
        }

        public async Task<List<Cuenta>> GetAll()
        {
            var cuentas = await _context.Cuentas.ToListAsync();
            if (cuentas is not null)
            {
                return cuentas;
            }
            else
            {
                return new List<Cuenta>();
            }
        }

        public async Task<List<Cuenta>> GetCuentasAutorizadas()
        {
            ulong usuarioDni;
            if (_httpContextAccesor.HttpContext != null)
            {
                usuarioDni = Convert.ToUInt64(_httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var cuentas = await _context.Cuentas.Where(c => c.UsuarioDni == usuarioDni).ToListAsync();
                return cuentas;
            }
            else
            {
                return new List<Autorizada>();
            }
        }

        public async Task<List<Cuenta>> GetCuentasUsuario()
        {
            ulong idUsuario;
            if(_httpContextAccesor.HttpContext != null)
            {
                idUsuario = Convert.ToUInt64(_httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var cuentas = await _context.Cuentas.Where(c => c.UsuarioDni == idUsuario).ToListAsync();
                return cuentas;
            }
            else
            {
                return new List<Cuenta>();
            }
        }
    }
}
