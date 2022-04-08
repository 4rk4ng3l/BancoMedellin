using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("GetAll")]
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
        public async Task<ActionResult<Usuario>> GetUsuarioById(ulong Dni)
        {
            try
            {
                return Ok(await _usuarioService.GetUsuarioById(Dni));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
