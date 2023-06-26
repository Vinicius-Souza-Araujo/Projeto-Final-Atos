using FrontEndProjetoFinalAtos.Models;

namespace FrontEndProjetoFinalAtos.ViewsModels
{
    public class PedidoViewModel
    {
        public Pedido Pedido { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public List<Produto> Produtos { get; set; }

        public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
    }
}
