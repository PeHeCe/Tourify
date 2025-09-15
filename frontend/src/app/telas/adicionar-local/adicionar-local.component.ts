import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Route, Router, RouterLink, RouterLinkActive } from "@angular/router";
import { HeaderSecundarioComponent } from "../../header-secundario.component";
import { EstabelecimentoService } from "../../estabelecimento/estabelecimento.service";
import { FormsModule, NgForm } from "@angular/forms";
import { CronogramaService } from "../../cronograma/cronograma.service";

@Component({
    selector: 'tela-adicionar-local',
    standalone: true,
    imports: [HeaderSecundarioComponent, FormsModule],
    templateUrl: './adicionar-local.component.html',
    styleUrl: './adicionar-local.component.css'
})
export class TelaAdicionarLocalComponent implements OnInit {

    idCronograma: number | null = null
    estabelecimentos: any

    constructor(private route: ActivatedRoute, private estabelecimentoService: EstabelecimentoService, private cronoService: CronogramaService) {}

    ngOnInit(): void {
        this.idCronograma = Number(this.route.snapshot.paramMap.get('idCronograma'));
    }

    buscarEstabelecimentos(form: NgForm) {
        this.estabelecimentoService.buscarEstabelecimento(form.value.busca).subscribe({
            next: (retorno: any) => {
                console.log(retorno)
                this.estabelecimentos = retorno
            },
            error: (dadosErro) => {
                console.log("Erro Subscribe = ", dadosErro)
                console.log(dadosErro)
            }
        })
    }

    adicionarAoCronograma(idEstabelecimento: number) {
        if (this.idCronograma) {
            this.cronoService.addEstabelecimentoToCronograma(this.idCronograma, idEstabelecimento).subscribe({
                next: (retorno: any) => {
                    console.log(retorno)
                    alert("Local adicionado ao seu cronograma!")
                },
                error: (dadosErro) => {
                    console.log("Erro Subscribe = ", dadosErro)
                    console.log(dadosErro)
                }
            })
        }
    }
}