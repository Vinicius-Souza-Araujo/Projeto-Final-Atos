using System.Text.Json.Serialization;

namespace FrontEndProjetoFinalAtos.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public bool? Ativo { get; set; } = true;


    }

}
