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
        public async Task<List<Cuenta>> GetCuentasUsuario()
        {
            int idUsuario;
            if (_httpContextAccesor.HttpContext != null)
            {
                idUsuario = Convert.ToInt32(_httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var cuentas = await _context.Cuentas.Where(c => c.UsuarioDni == idUsuario).ToListAsync();
                return cuentas;
            }
            else
            {
                return new List<Cuenta>();
            }
        }
       

        public async Task<List<Cuenta>> GetCuentasAutorizadas()
        {
            int usuarioDni;
            if (_httpContextAccesor.HttpContext != null)
            {
                usuarioDni = Convert.ToInt32(_httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                
                var autorizadas = await _context.Autorizadas.Where(aut => aut.UsuarioDni == usuarioDni).Select(x => x.CuentaId).ToListAsync();
                var cuentas = await _context.Cuentas.Where(c => autorizadas.Contains(c.Id)).ToListAsync();  
               
                return cuentas;
            }
            else
            {
                return new List<Cuenta>();
            }
        }
    }
}
