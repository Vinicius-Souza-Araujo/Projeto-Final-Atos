namespace FrontEndProjetoFinalAtos.Models
{
    public class ItensPedido
    {
        public int Id { get; set; }

        public int? FkPedido { get; set; }

        public int? FkProduto { get; set; }

        public int? Quantidade { get; set; }

        public virtual Pedido? FkPedidoNavigation { get; set; }

        public virtual Produto? FkProdutoNavigation { get; set; }
    }
}
