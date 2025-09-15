import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Route, RouterLink, RouterLinkActive } from "@angular/router";
import { HeaderSecundarioComponent } from "../../header-secundario.component";
import { EstabelecimentoService } from "../../estabelecimento/estabelecimento.service";
import { Estabelecimento } from "../../estabelecimento/estabelecimento.model";
import { CommonModule } from "@angular/common";

@Component({
    selector: 'tela-estabelecimento',
    standalone: true,
    imports: [CommonModule, HeaderSecundarioComponent],
    templateUrl: './estabelecimento.component.html',
    styleUrl: './estabelecimento.component.css'
})
export class TelaEstabelecmentoComponent implements OnInit {

    estabelecimento: any
    paramIdEstabelecimento: string | null = null;

    constructor(private route: ActivatedRoute, private estabelecimentoServie: EstabelecimentoService) {}

    ngOnInit(): void {
        this.paramIdEstabelecimento = this.route.snapshot.paramMap.get('idEstabelecimento')

        if (this.paramIdEstabelecimento) {
            this.estabelecimentoServie.getEstabelecimentoById(this.paramIdEstabelecimento).subscribe({
                next: (retorno: any) => {
                    console.log(retorno)
                    this.estabelecimento = retorno
                },
                error: (dadosErro) => {
                    console.log("Erro Subscribe = ", dadosErro)
                    console.log(dadosErro)
                }
            })
        }
    }
}