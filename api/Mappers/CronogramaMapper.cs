using api.Classes;

namespace api.Mappers
{
	public class CronogramaMapper
	{
		public static Cronograma CronogramaToClasses(Models.Cronograma cronograma_model)
		{
			return new Cronograma
			{
				cronograma = cronograma_model
			};
		}
	}
}
