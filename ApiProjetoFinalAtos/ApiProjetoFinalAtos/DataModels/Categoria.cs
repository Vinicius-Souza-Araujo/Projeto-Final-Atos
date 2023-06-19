using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiProjetoFinalAtos.DataModels;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public bool? Ativo { get; set; }

    
    [JsonIgnore]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
