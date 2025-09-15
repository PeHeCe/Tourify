namespace api.DTOs
{
	public class ListaCronogramasDTO
	{
		public int id { get; set; }
		public string papel_usuario { get; set; }
		public string nome { get; set; }
		public DateOnly data { get; set; }
		public TimeOnly hora_inicio { get; set; }
		public TimeOnly hora_fim { get; set; }
	}
}
