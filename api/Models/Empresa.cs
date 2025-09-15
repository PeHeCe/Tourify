namespace api.Models
{
    public class Empresa
    {
        public required int id { get; set; }
        public required string nome { get; set; } = string.Empty;
        public required string cnpj { get; set; } = string.Empty;
        public List<Excursao>? excursoes { get; set; } = [];
    }
}