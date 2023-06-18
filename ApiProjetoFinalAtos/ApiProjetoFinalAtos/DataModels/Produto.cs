using System;
using System.Collections.Generic;

namespace ApiProjetoFinalAtos.DataModels;

public partial class Produto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public decimal? Valor { get; set; }

    public int? FkCategoria { get; set; }

    public bool? Ativo { get; set; }

    public virtual Categoria? FkCategoriaNavigation { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
