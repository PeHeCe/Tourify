import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Route, Router, RouterLink, RouterLinkActive } from "@angular/router";
import { HeaderPrincipalComponent } from "../../header-principal.component";
import { CronogramaService } from "../../cronograma/cronograma.service";

@Component({
    selector: 'tela-buscar-cronogramas',
    standalone: true,
    imports: [HeaderPrincipalComponent],
    templateUrl: './buscar-cronogramas.component.html',
    styleUrl: './buscar-cronogramas.component.css'
})
export class TelaBuscarCronogramasComponent implements OnInit {

    cronogramas: any

    constructor(private router: Router, private cronoService: CronogramaService) {}

    ngOnInit(): void {
        this.cronoService.getCronogramasPublicos().subscribe({
            next: (retorno: any) => {
                console.log(retorno)
                this.cronogramas = retorno
            },
            error: (dadosErro) => {
                console.log("Erro Subscribe = ", dadosErro)
                console.log(dadosErro)
            }
        })
    }

    navegarCronograma(idCronograma: number) {
        this.router.navigate([`/cronograma/${idCronograma}`])
    }
}