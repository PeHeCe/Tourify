namespace api.Models
{
    public class Estabelecimento
    {
        public required int id { get; set; }
        public required string nome { get; set; } = string.Empty;
        public required string endereco { get; set; } = string.Empty;
        public required string cnpj { get; set; } = string.Empty;
        public string telefone_contato { get; set; } = string.Empty;
        public TimeOnly horario_abertura { get; set; } = TimeOnly.MinValue;
        public TimeOnly horario_fechamento { get; set; } = TimeOnly.MinValue;
        public string nivel_preco { get; set; } = string.Empty;
        public string descricao { get; set; } = string.Empty;
        public string site { get; set; } = string.Empty;
        public int tipo_estabelecimento_id { get; set; }
        public required TipoEstabelecimento tipo_estabelecimento { get; set; }
        public string imagem { get; set; } = string.Empty;
    }
}