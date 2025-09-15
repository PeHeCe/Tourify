using System.ComponentModel.DataAnnotations.Schema;
using api.Models;

namespace api.Models
{
    public class Cronograma
    {
        public required int id { get; set; }
        public string nome { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal custo_maximo { get; set; } = 0;
        public required DateOnly data { get; set; }
        public required TimeOnly hora_inicio { get; set; }
        public required TimeOnly hora_fim { get; set; }
        public bool publico { get; set; }
        public List<UsuarioCronograma> usuarios_cronogramas { get; set; } = [];
    }
}