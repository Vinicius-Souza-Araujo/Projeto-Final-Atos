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

        [HttpGet("pedidos/preparado")]
        public async Task<IActionResult> getPreparedAsync([FromServices] ProjetoFinalContext contexto)
        {
            var pedidos = await contexto.Pedidos.AsNoTracking().Where(p => p.Andamento == "preparado").ToListAsync();

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

        [HttpPut("pedidos/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] ProjetoFinalContext contexto, [FromBody] Pedido pedido, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválida!");
            }

            var p = await contexto.Pedidos.FirstOrDefaultAsync(p => p.Id == id);

            if (p == null)
            {
                return NotFound("Pedido não encontrado!");
            }

            try
            {
               
             
                p.Andamento = pedido.Andamento.ToLower();
                contexto.Pedidos.Update(p);
                await contexto.SaveChangesAsync();
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
