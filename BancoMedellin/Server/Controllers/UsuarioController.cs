using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BancoMedellin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        [HttpGet("GetAll"),Authorize]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            try
            {
                return Ok(await _usuarioService.GetAll());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Dni}")]
        public async Task<ActionResult<Usuario>> GetUsuarioByDni(ulong Dni)
        {
            try
            {
                Usuario usuario = await _usuarioService.GetUsuarioByDni(Dni);   
                if(usuario is not null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NotFound("No se encontro el usuario!.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("Registrar"), AllowAnonymous]
        public async Task<ActionResult<Usuario>> Registrar(UsuarioDTO request)
        {
            try
            {
                return Ok(await _usuarioService.Registrar(request));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("Login"), AllowAnonymous]
        public async Task<ActionResult> Login(UsuarioDTO request)
        {
            try
            {
                string login = await _usuarioService.Login(request);
                switch(login)
                {
                    case "NotFound":
                        return NotFound("Usuario o contraseña errada!.");
                        
                    case "MissMatch":
                        return BadRequest("Usuario o contraseña errada!.");
                        
                    default:
                        return Ok(login);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
       
    }
}
