using System;
using System.Collections.Generic;

namespace ApiProjetoFinalAtos.DataModels;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public bool? Ativo { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
