import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { HeaderSecundarioComponent } from "../../header-secundario.component";
import { CronogramaService } from "../../cronograma/cronograma.service";

@Component({
    selector: 'tela-meus-cronogramas',
    standalone: true,
    imports: [HeaderSecundarioComponent],
    templateUrl: './meus-cronogramas.component.html',
    styleUrl: './meus-cronogramas.component.css'
})
export class TelaMeusCronogramasComponent implements OnInit {

    cronogramas: any

    constructor(private router: Router, private cronoService: CronogramaService) {}

    ngOnInit(): void {
        this.cronoService.getCronogramasByUsuario(Number(localStorage.getItem("idUsuario"))).subscribe({
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

    formatarData(data: string) {
        var dataObj = new Date(data)
    
        return new Intl.DateTimeFormat('pt-BR', {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric',
        }).format(dataObj);
    }

    formatarHorario(hora: string) {
        var partes = hora.split(":")
        return partes[0] + ":" + partes[1]
    }
}