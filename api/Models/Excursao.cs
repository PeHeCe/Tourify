using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Excursao
    {
        public required int id { get; set; }
        public string? local_partida { get; set; } = string.Empty;
        public string? local_destino { get; set; } = string.Empty;
        public DateOnly? data { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? preco { get; set; }
        public string? descricao { get; set; } = string.Empty;
        public required Empresa empresa { get; set; }
        public Cronograma? cronograma { get; set; }
    }
}