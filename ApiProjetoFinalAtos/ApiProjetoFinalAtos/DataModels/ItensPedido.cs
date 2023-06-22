using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetoFinalAtos.DataModels;

public partial class ItensPedido
{

    public int Id { get; set; }

    public int? FkPedido { get; set; }

    public int? FkProduto { get; set; }

    public int? Quantidade { get; set; }

    public virtual Pedido? FkPedidoNavigation { get; set; }

    public virtual Produto? FkProdutoNavigation { get; set; }
}
