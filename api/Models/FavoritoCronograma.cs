using api.Models;

namespace api.Models
{
    public class FavoritoCronograma
    {
        public int id { get; set; }
        public required string apelido { get; set; } = string.Empty;
        public required Cronograma cronograma { get; set; }
        public required Usuario usuario { get; set; }
    }
}