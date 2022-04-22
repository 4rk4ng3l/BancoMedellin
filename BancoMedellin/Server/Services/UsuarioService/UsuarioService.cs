using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BancoMedellin.Server.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private Utilidades _util;
        public UsuarioService(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccesor = httpContextAccessor;
            _context = context;
            _configuration = configuration;
            _util = new Utilidades();
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if(_httpContextAccesor.HttpContext != null)
            {
                result = _httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

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

        public async Task<Usuario> Registrar(UsuarioDTO request)
        {
            try
            {
                _util.createPasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                Usuario Usuario = new Usuario();
                Usuario.Dni = Convert.ToUInt64(request.Dni);
                Usuario.Nombre = request.Nombre;
                Usuario.PasswordHash = passwordHash;
                Usuario.PasswordSalt = passwordSalt;
                await _context.Usuarios.AddAsync(Usuario);
                await _context.SaveChangesAsync();
                return Usuario;
            }catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string>Login(UsuarioDTO request)
        {
            try
            {
                Usuario usuario = await GetUsuarioByDni(Convert.ToUInt64(request.Dni));

                if (usuario is not null)
                {
                    if (_util.VerifyPasswordHash(request.Password, usuario.PasswordHash, usuario.PasswordSalt))
                    {
                        string secretKey = _configuration.GetSection("AppSettings:Token").Value;
                        string token = _util.CreateToken(usuario, secretKey);

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
