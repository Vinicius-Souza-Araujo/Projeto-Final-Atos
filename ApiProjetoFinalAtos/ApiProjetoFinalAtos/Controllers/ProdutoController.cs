using ApiProjetoFinalAtos.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoFinalAtos.Controllers
{
    [Route("produtocontroller")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        [HttpGet("produtos")]
        public async Task<IActionResult> getAllAsync([FromServices] ProjetoFinalContext contexto)
        {
            var produtos = await contexto.Produtos.AsNoTracking().Include(p => p.FkCategoriaNavigation).ToListAsync();
            return produtos == null ? NotFound() : Ok(produtos);

        }

        [HttpGet("produtos/ativos")]
        public async Task<IActionResult> getActiveProductsAsync([FromServices] ProjetoFinalContext contexto)
        {
            var produtosAtivos = await contexto.Produtos.AsNoTracking().Where(p => p.Ativo == true).Include(p => p.FkCategoriaNavigation).ToListAsync();
            return produtosAtivos == null ? NotFound() : Ok(produtosAtivos);
        }

        [HttpGet("produtos/inativos")]
        public async Task<IActionResult> getInactiveProductsAsync([FromServices] ProjetoFinalContext contexto)
        {
            var produtosInativos = await contexto.Produtos.AsNoTracking().Where(p => p.Ativo == false).Include(p => p.FkCategoriaNavigation).ToListAsync();
            return produtosInativos == null ? NotFound() : Ok(produtosInativos);
        }

        [HttpPost("produtos")]
        public async Task<IActionResult> PostAsync([FromServices] ProjetoFinalContext contexto, [FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            try
            {
                produto.Nome = produto.Nome.ToLower();
                await contexto.Produtos.AddAsync(produto);
                await contexto.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("produtos/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] ProjetoFinalContext contexto, [FromBody] Produto produto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválida!");
            }

           

            var p = await contexto.Produtos.FirstOrDefaultAsync(p => p.Id == id);


            if(p == null) 
            {
                return NotFound("Produto não encontrado!");
            }

            try
            {
                p.Nome = produto.Nome.ToLower();
                p.Valor = produto.Valor;
                p.Ativo = produto.Ativo;
                p.FkCategoria = produto.FkCategoria;
               

                contexto.Produtos.Update(p);
                await contexto.SaveChangesAsync();
                return Ok(p);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
