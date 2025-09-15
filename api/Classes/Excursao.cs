using api.DTOs;

namespace api.Classes
{
    public class Excursao
    {
        public required Models.Excursao excursao { get; set; }

        public void AtribuirCronograma(Cronograma cronograma)
        {
            this.excursao.cronograma = cronograma.cronograma;
        }

        public void EditarExcursao(ExcursaoEdit excursaoEdit)
        {
            this.excursao.local_partida = excursaoEdit.local_partida ?? this.excursao.local_partida;
            this.excursao.local_destino = excursaoEdit.local_destino ?? this.excursao.local_destino;
            this.excursao.preco = excursaoEdit.preco ?? this.excursao.preco;
            this.excursao.data = excursaoEdit.data ?? this.excursao.data;
            this.excursao.descricao = excursaoEdit.descricao ?? this.excursao.descricao;
            this.excursao.cronograma = excursaoEdit.cronograma ?? this.excursao.cronograma;
        }
    }
}
