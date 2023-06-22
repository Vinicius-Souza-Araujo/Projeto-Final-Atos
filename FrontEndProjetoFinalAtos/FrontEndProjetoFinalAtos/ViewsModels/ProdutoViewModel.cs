using FrontEndProjetoFinalAtos.Models;

namespace FrontEndProjetoFinalAtos.ViewsModels
{
    public class ProdutoViewModel
    {
        public List<Produto> Produtos { get; set; }
        public Produto Produto { get; set; }

        public List<Categoria> Categorias { get; set; }

    }
}
