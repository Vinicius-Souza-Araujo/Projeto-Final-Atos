namespace FrontEndProjetoFinalAtos.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public int? Mesa { get; set; }

        public string? Andamento { get; set; }

        public string? Cliente { get; set; }

        public DateTime? DataHora { get; set; }

        public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
    }
}
