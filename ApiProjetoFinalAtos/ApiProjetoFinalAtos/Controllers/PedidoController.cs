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

        [HttpPost("pedidos")]
        public async Task<IActionResult> PostAsync([FromServices] ProjetoFinalContext contexto, [FromBody] Pedido pedido)
        {
            //var transaction = await contexto.Database.BeginTransactionAsync();
            try
            {
                await contexto.Pedidos.AddAsync(pedido);
                await contexto.SaveChangesAsync();

                //if (pedido.ItensPedidos != null && pedido.ItensPedidos.Any())
                //{
                    
                //    foreach (var itemPedido in pedido.ItensPedidos)
                //    {
                //        itemPedido.FkPedido = pedido.Id;
                //        itemPedido.FkPedidoNavigation = pedido;

                        
                //        var produtoExistente = await contexto.Produtos.FindAsync(itemPedido.FkProduto);
                //        if (produtoExistente != null)
                //        {
                //            itemPedido.FkProdutoNavigation = produtoExistente;

                            
                //            contexto.ItensPedidos.Add(itemPedido);
                //        }
                //    }
                //    await contexto.SaveChangesAsync();
                    
                //}
                //await transaction.CommitAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                //await transaction.RollbackAsync();

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }


                return BadRequest(ex.Message);
            }
        }
    }
}
