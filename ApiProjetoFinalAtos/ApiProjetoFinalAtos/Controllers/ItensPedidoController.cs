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


            //foreach(var item in itensPedidos)
            //{
               
                
            //    string sqlPedido = @$"select * from pedidos where id = {item.FkPedido}";
            //    var pedido = await contexto.Pedidos.FromSqlRaw<Pedido>(sqlPedido).FirstOrDefaultAsync();
            //    item.FkPedidoNavigation = pedido;
                
               

                

            //}


            


            return itensPedidos == null ? NotFound() : Ok(itensPedidos);
        }

        //[HttpPost("itenspedidos")]
        //public async Task<IActionResult> PostAsync([FromServices] ProjetoFinalContext contexto, [FromBody] ItensPedido itensPedido, [FromQuery] string nomeProdudo)
        //{

        //}
    }
}
