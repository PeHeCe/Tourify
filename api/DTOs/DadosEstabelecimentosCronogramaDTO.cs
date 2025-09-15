namespace api.DTOs
{
	public class DadosEstabelecimentosCronogramaDTO
	{
		public int id { get; set; }
		public int idEstabelecimento { get; set; }
		public string nome { get; set; }
		public TimeOnly horario { get; set; }
		public string endereco { get; set; }
		public string imagem { get; set; }
	}
}
