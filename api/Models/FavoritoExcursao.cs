using api.Models;

namespace api.Models
{
    public class FavoritoExcursao
    {
        public int id { get; set; }
        public required string apelido { get; set; } = string.Empty;
        public required Excursao excursao { get; set; }
        public required Usuario usuario { get; set; }
    }
}