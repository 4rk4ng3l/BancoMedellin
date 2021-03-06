using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BancoMedellin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }


        [HttpGet("GetCuentasUsuario")]
        public async Task<ActionResult<List<Cuenta>>> GetCuentasUsuario()
        {
            try
            {
                return Ok(await _cuentaService.GetCuentasUsuario());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCuentasAutorizadas")]
        public async Task<ActionResult<List<Cuenta>>> GetCuentasAutorizadas()
        {
            try
            {
                return Ok(await _cuentaService.GetCuentasAutorizadas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
