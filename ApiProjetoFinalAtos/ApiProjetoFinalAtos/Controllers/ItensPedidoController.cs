using ApiProjetoFinalAtos.DataModels;
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
            var itensPedidos = await contexto.ItensPedidos.Include(p => p.FkProdutoNavigation).AsNoTracking().ToListAsync();


            return itensPedidos == null ? NotFound() : Ok(itensPedidos);
        }

        [HttpGet("itenspedidos/{id}")]
        public async Task<IActionResult> getByIdPedidosAsync([FromServices] ProjetoFinalContext contexto, [FromRoute] int id)
        {
            var itensPedidos = await contexto.ItensPedidos.Include(p => p.FkProdutoNavigation).AsNoTracking().Where(p => p.FkPedido == id).ToListAsync();


            return itensPedidos == null ? NotFound() : Ok(itensPedidos);
        }
    }
}
