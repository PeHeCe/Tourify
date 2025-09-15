namespace api.Models
{
	public class EstabelecimentoCronograma
	{
		public int id { get; set; }
		public Cronograma cronograma { get; set; } = null!;
		public Estabelecimento estabelecimento { get; set; } = null!;
		public TimeOnly horario { get; set; }
	}
}
