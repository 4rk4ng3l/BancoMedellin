//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;


//namespace BancoMedellin.Server.Services.CuentaService
//{
//    public class CuentaService : ICuentaService
//    {
//        private readonly DataContext _context;

//        public CuentaService(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<List<Cuenta>> GetAll()
//        {
//            var cuentas = await _context.Cuentas.ToListAsync();
//            if(cuentas is not null)
//            {
//                return cuentas;
//            }
//            else
//            {
//                return new List<Cuenta>();
//            }
//        }
//    }
//}
