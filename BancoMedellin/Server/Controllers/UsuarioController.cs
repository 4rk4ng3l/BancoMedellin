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
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            try
            {
                return Ok(await _usuarioService.GetAll());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> GetUsuarioById(ulong id)
        {
            try
            {
                return Ok(await _usuarioService.GetUsuarioById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
