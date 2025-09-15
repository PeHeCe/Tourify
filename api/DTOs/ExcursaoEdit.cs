using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs
{
    public class ExcursaoEdit
    {
        public string? local_partida { get; set; } = string.Empty;
        public string? local_destino { get; set; } = string.Empty;
        public DateOnly? data { get; set; }
        public decimal? preco { get; set; }
        public string? descricao { get; set; } = string.Empty;
        public Cronograma? cronograma { get; set; }
    }
}