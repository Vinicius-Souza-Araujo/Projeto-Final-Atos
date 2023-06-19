using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoFinalAtos.Controllers
{
    [Route("itenspedidocontroller")]
    [ApiController]
    public class ItensPedidoController : ControllerBase
    {
        [HttpGet("itenspedidos")]
        public async Task<IActionResult> getAllAsync([FromServices] ProjetoFinalContext contexto)
        {
            var itensPedidos = await contexto.ItensPedidos.AsNoTracking().ToListAsync();
            return itensPedidos == null ? NotFound() : Ok(itensPedidos);
        }
    }
}
