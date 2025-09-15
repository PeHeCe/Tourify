using api.Models;

namespace api.Models
{
    public class FavoritoEstabelecimento
    {
        public int id { get; set; }
        public required string apelido { get; set; } = string.Empty;
        public required Estabelecimento estabelecimento { get; set; }
        public required Usuario usuario { get; set; }
    }
}