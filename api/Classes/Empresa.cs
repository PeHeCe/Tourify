namespace api.Classes
{
    public class Empresa
    {
        public required Models.Empresa empresa { get; set; }

        public void CriarExcursao(string localPartida, string localDestino, DateOnly data, double preco, string descricao, int idCronograma)
        {
            // Implementar com banco de dados
        }
    }
}
