namespace api.Models
{
    public class Avaliacao
    {
        public required int id { get; set; }
        public required int nota { get; set; }
        public required string mensagem { get; set; }
        public required Usuario usuario { get; set; }
        public required Estabelecimento estabelecimento { get; set; }
    }
}