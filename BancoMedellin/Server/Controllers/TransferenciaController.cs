using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoMedellin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _transferenciaService;
        public TransferenciaController(ITransferenciaService transferenciaService)
        {
            _transferenciaService = transferenciaService;
        }

        [HttpPost("SaveTransferenciaPropia")]
        public async Task<ActionResult> SaveTransferenciaPropia(TransferenciaDto transferenciaDto)
        {
            string mensaje = await _transferenciaService.SaveTransferenciaPropia(transferenciaDto);
            return Ok(mensaje );
        }
        [HttpPost("SaveTransferenciaTercero")]
        public async Task<ActionResult> SaveTransferenciaTercero(TransferenciaDto transferenciaDto)
        {
            string mensaje = await _transferenciaService.SaveTransferenciaTercero(transferenciaDto);
            return Ok(mensaje);
        }
    }
}
