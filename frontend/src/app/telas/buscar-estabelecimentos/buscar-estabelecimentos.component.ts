import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { HeaderPrincipalComponent } from "../../header-principal.component";
import { EstabelecimentoService } from "../../estabelecimento/estabelecimento.service";
import { FormsModule, NgForm } from "@angular/forms";
import { CommonModule } from "@angular/common";

@Component({
    selector: 'tela-buscar-estabelecimentos',
    standalone: true,
    imports: [HeaderPrincipalComponent, FormsModule, CommonModule],
    templateUrl: './buscar-estabelecimentos.component.html',
    styleUrl: './buscar-estabelecimentos.component.css'
})
export class TelaBuscarEstabelecimentosComponent {

    estabelecimentos: any[] = []

    constructor(private router: Router, private estabelecimentoService: EstabelecimentoService) {}

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

    navegarTelaEstabelecimento(idEstabelecimento: string): void {
        this.router.navigate([`/estabelecimento/${idEstabelecimento}`])
    }
}