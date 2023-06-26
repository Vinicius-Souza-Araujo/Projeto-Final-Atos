using ApiProjetoFinalAtos.DataModels;
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

        [HttpGet("pedidos/emAndamento")]
        public async Task<IActionResult> getInProgressAsync([FromServices] ProjetoFinalContext contexto)
        {
            var pedidos = await contexto.Pedidos.AsNoTracking().Where(p => p.Andamento == "em andamento").ToListAsync();

            return pedidos == null ? NotFound() : Ok(pedidos);
        }

        [HttpPost("pedidos")]
        public async Task<IActionResult> PostAsync([FromServices] ProjetoFinalContext contexto, [FromBody] Pedido pedido)
        {
            
            try
            {
                await contexto.Pedidos.AddAsync(pedido);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }


                return BadRequest(ex.Message);
            }
        }
    }
}
