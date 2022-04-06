using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BancoMedellin.Server.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DataContext _context;
        public UsuarioService(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Usuario>> GetAll()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            if(usuarios is not null)
            {
                return usuarios;
            }
            else
            {
                return new List<Usuario>();
            }
            
        }
        [HttpGet("{id}")]
        public async Task<Usuario>GetUsuarioById(ulong Dni)
        {
            var usuario = await _context.Usuarios.SingleAsync(u => u.Dni == Dni);
            if(usuario is not null)
            {
                return usuario;
            }
            else
            {
                return new Usuario();   
            }
            
        }
    }
}
