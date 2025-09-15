import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router"; 
import { EstabelecimentoService } from "../../estabelecimento/estabelecimento.service";
import { CronogramaService } from "../../cronograma/cronograma.service";
import { HeaderSecundarioComponent } from "../../header-secundario.component";

@Component({
  selector: 'app-editar-estabelecimento',
  templateUrl: './editar-cronograma.component.html',
  styleUrls: ['./editar-cronograma.component.css'],
  standalone: true,
  imports: [HeaderSecundarioComponent]
})
export class TelaEditarCronogramaComponent implements OnInit {
    idCronograma: number | null = null;
    cronograma: any;
    estabelecimentos: any;

    constructor(
        private cronoService: CronogramaService,
        private router: Router,
        private route: ActivatedRoute
    ) {}

    ngOnInit(): void {
        this.idCronograma = Number(this.route.snapshot.paramMap.get('idCronograma'));

        this.recuperarDadosCronograma()
    }

    recuperarDadosCronograma() {
      if (this.idCronograma) {
        this.cronoService.getDadosCronograma(this.idCronograma).subscribe({
          next: (retorno) => {
              this.cronograma = retorno.cronograma;
              this.estabelecimentos = retorno.estabelecimentos;
              console.log(retorno)
          },
          error: (err) => {
              console.error("Erro ao carregar estabelecimentos:", err);
          }
        });
      }
    }

    excluirEstabelecimento(id: number): void {
      if (confirm('Tem certeza que deseja excluir este estabelecimento?')) {
        this.cronoService.deleteEstabelecimentoFromCronograma(id).subscribe({
          next: (retorno) => {
              console.log(retorno)
              this.recuperarDadosCronograma()
          },
          error: (err) => {
              console.error("Erro ao excluir estabelecimento deste cronograma:", err);
          }
        });
      }
    }

    navegarAdicionarEstabelecimento(id: number): void {
      if (id) {
          this.router.navigate([`/cronograma/editar/adicionar_estabelecimento/`, id]);
      } else {
          console.error("ID não encontrado");
      }
    }

    salvar() {
      if (confirm('Deseja salvar suas alterações e voltar aos detalhes do seu cronograma?')) {
        this.router.navigate([`/cronograma/`, this.idCronograma]);
      }
    }

}
