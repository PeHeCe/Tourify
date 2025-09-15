using api.DTOs;

namespace api.Classes
{
    public class Usuario
    {
        public required Models.Usuario usuario { get; set; }

        public void EditarCadastro(UsuarioEdit usuarioEdit)
        {
            this.usuario.nome = usuarioEdit.nome ?? this.usuario.nome;
            this.usuario.sobrenome = usuarioEdit.sobrenome ?? this.usuario.sobrenome;
            this.usuario.telefone = usuarioEdit.telefone ?? this.usuario.telefone;
            this.usuario.cep = usuarioEdit.cep ?? this.usuario.cep;
            this.usuario.email = usuarioEdit.email ?? this.usuario.email;
            this.usuario.senha = usuarioEdit.senha ?? this.usuario.senha;
        }

        public void ExcluirCadastro()
        {
            // Implementar com Banco de dados
        }

        public void CriarCronogramaAutomatico(string nome, DateOnly data, TimeOnly horarioInicio, TimeOnly horarioFim, double custoMaximo, string local)
        {
            // Implementar com Banco de dados
        }

        public void CriarCronogramaPersonalizado(string nome, DateOnly data, TimeOnly horarioInicio, TimeOnly horarioFim)
        {
            // Implementar com Banco de dados
        }

        public void ExcluirCronograma(int IdCronograma)
        {
            // Implementar com Banco de dados
        }

        public void AvaliarEstabelecimento(int idEstabelecimento, int nota, string mensagem)
        {
            // Implementar com Banco de dados
        }

        public void FavoritarExcursao(int IdExcursao)
        {
            // Implementar com Banco de dados
        }
        public void FavoritarEstabelecimento(int IdEstabelecimento)
        {
            // Implementar com Banco de dados
        }

        public void FavoritarCronograma(int IdCronograma)
        {
            // Implementar com Banco de dados
        }
    }
}
