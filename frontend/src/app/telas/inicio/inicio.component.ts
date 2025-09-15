import { Component, OnInit } from "@angular/core";
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { HeaderPrincipalComponent } from "../../header-principal.component";
import { EstabelecimentoService } from "../../estabelecimento/estabelecimento.service";
import { Estabelecimento } from "../../estabelecimento/estabelecimento.model";
import { CommonModule } from "@angular/common";

@Component({
    selector: 'tela-inicio',
    standalone: true,
    imports: [HeaderPrincipalComponent, CommonModule],
    templateUrl: './inicio.component.html',
    styleUrl: './inicio.component.css'
})
export class TelaInicioComponent implements OnInit {

    estabelecimentos: any[] = []

    constructor(private router: Router, private estabelecimentoService: EstabelecimentoService) {}

    ngOnInit(): void {
        this.estabelecimentoService.getAllEstabelecimento().subscribe({
            next: (retorno: any) => {
                console.log(retorno)
                // console.log({_id: dadosSucesso.messageList[0]._id, content: dadosSucesso.messageList[0].content})

                this.estabelecimentos = retorno

                console.log(this.estabelecimentos)
            },
            error: (dadosErro) => {
                console.log("Erro Subscribe = ", dadosErro.info_extra)
                console.log(dadosErro)
            }
        })
    }

    navegarTelaEstabelecimento(idEstabelecimento: string): void {
        this.router.navigate([`/estabelecimento/${idEstabelecimento}`])
    }
}