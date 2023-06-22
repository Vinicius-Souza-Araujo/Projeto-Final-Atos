using ApiProjetoFinalAtos.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoFinalAtos.Controllers
{
    [Route("categoriacontroller")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet("categorias")]
        public async Task<IActionResult> getAllAsync([FromServices] ProjetoFinalContext contexto)
        {
            var categorias = await contexto.Categorias.AsNoTracking().ToListAsync();
            return categorias == null ? NotFound() : Ok(categorias);
        }

        [HttpGet("categorias/ativas")]
        public async Task<IActionResult> getActiveCategoriesAsync([FromServices] ProjetoFinalContext contexto)
        {
            var categoriasAtivas = await contexto.Categorias.AsNoTracking().Where(c => c.Ativo == true).ToListAsync();
            return categoriasAtivas == null ? NotFound() : Ok(categoriasAtivas);
        }

        [HttpGet("categorias/inativas")]
        public async Task<IActionResult> getInactiveCategoriesAsync([FromServices] ProjetoFinalContext contexto)
        {
            var categoriasInativas = await contexto.Categorias.AsNoTracking().Where(c => c.Ativo == false).ToListAsync();
            return categoriasInativas == null ? NotFound() : Ok(categoriasInativas);
        }

        [HttpGet("categorias/{id}")]
        public async Task<IActionResult> getByIdAsync([FromServices] ProjetoFinalContext contexto, [FromRoute] int id)
        {
            var categoria = await contexto.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return categoria == null ? NotFound() : Ok(categoria);

        }


        [HttpPost("categorias")]
        public async Task<IActionResult> PostAsync([FromServices] ProjetoFinalContext contexto, [FromBody] Categoria categoria)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                categoria.Nome = categoria.Nome.ToLower();
                await contexto.Categorias.AddAsync(categoria);
                await contexto.SaveChangesAsync();
                return Created($"categoriacontroller/categorias/{categoria.Id}", categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("categorias/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] ProjetoFinalContext contexto, [FromBody] Categoria categoria, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model inválida!");
            }
            
            var c = await contexto.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            if (c == null)
            {
                return NotFound("Categoria não encontrada!");
            }

            try
            {
                c.Nome = categoria.Nome.ToLower(); ;
                c.Ativo = categoria.Ativo;
                contexto.Categorias.Update(c);
                await contexto.SaveChangesAsync();
                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
