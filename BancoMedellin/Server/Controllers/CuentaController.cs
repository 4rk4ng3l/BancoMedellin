//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace BancoMedellin.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CuentaController : ControllerBase
//    {
//        private readonly ICuentaService _cuentaService;

//        public CuentaController(ICuentaService cuentaService)
//        {
//            _cuentaService = cuentaService; 
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<Cuenta>>>GetAll()
//        {
//            try
//            {
//                return Ok(await _cuentaService.GetAll());
//            }catch (Exception ex)
//            {
//                return BadRequest(ex.Message);  
//            }
//        }
       
//    }
//}
