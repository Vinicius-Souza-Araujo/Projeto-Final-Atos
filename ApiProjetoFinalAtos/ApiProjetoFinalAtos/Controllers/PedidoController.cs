using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoFinalAtos.Controllers
{
    [Route("pedidocontroller")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpGet("pedidos")]
        public async Task<IActionResult> getAllAsync([FromServices] ProjetoFinalContext contexto)
        {
            var pedidos = await contexto.Pedidos.AsNoTracking().ToListAsync();
            return pedidos == null ? NotFound() : Ok(pedidos);
        }
    }
}
