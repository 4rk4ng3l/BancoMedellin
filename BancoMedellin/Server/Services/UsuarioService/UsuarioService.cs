using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace BancoMedellin.Server.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration; 
        public UsuarioService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<List<Usuario>> GetAll()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            if (usuarios is not null)
            {
                return usuarios;
            }
            else
            {
                return new List<Usuario>();
            }

        }
        [HttpGet("{Dni}")]
        
        public async Task<Usuario> GetUsuarioByDni(ulong Dni)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Dni == Dni);
                if (usuario is not null)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("Registrar")]
        public async Task<Usuario> Registrar(UsuarioDTO request)
        {
            Utilidades utilidades = new Utilidades();
            utilidades.createPasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Usuario Usuario = new Usuario();
            Usuario.Dni = request.Dni;
            Usuario.Nombre = request.Nombre;
            Usuario.PasswordHash = passwordHash;
            Usuario.PasswordSalt = passwordSalt;
            return Usuario;
            
        }

        [HttpPost("login")]
        public async Task<string>Login(UsuarioDTO request)
        {
            try
            {
                Utilidades utilidades = new Utilidades();
                Usuario usuario = await GetUsuarioByDni(request.Dni);

                if (usuario is not null)
                {
                    if (utilidades.VerifyPasswordHash(request.Password, usuario.PasswordHash, usuario.PasswordSalt))
                    {
                        string secretKey = _configuration.GetSection("AppSettings:Token").Value;
                        string token = utilidades.CreateToken(usuario, secretKey);

                        return token;
                    }
                    else
                    {
                        return "MissMatch";
                    }
                }
                else
                {
                    return "NotFound";
                }
            }catch (Exception ex)
            {
                throw;
            }
        }
    }
}
