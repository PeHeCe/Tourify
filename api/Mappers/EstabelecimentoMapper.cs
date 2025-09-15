using api.Classes;

namespace api.Mappers
{
	public static class EstabelecimentoMapper
	{
		public static Estabelecimento EstabelecimentoToClasses(Models.Estabelecimento estabelecimento_model)
		{
			return new Estabelecimento
			{
				estabelecimento = estabelecimento_model
			};
		}
	}
}
