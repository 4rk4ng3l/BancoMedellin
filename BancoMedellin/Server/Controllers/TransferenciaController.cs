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
            return Ok(await _transferenciaService.AddTransferencia(transferenciaDto));
        }
    }
}
