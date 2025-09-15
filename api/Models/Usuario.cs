namespace api.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public required string nome { get; set; }
        public required string sobrenome { get; set; }
        public required string telefone { get; set; }
        public required string cep { get; set; }
        public required string email { get; set; }
        public required string senha { get; set; }
        public required string cpf { get; set; }

        public List<Avaliacao> avaliacoes { get; set; } = [];
        public List<FavoritoCronograma> favoritos_cronogramas { get; set; } = [];
        public List<FavoritoEstabelecimento> favoritos_estabelecimentos { get; set; } = [];
        public List<FavoritoExcursao> favorito_excursoes { get; set; } = [];
    }
}