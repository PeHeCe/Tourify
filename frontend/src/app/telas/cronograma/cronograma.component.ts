import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";  
import { HeaderSecundarioComponent } from "../../header-secundario.component";
import { EstabelecimentoService } from "../../estabelecimento/estabelecimento.service";
import { CommonModule } from '@angular/common';
import { CronogramaService } from "../../cronograma/cronograma.service";

@Component({
    selector: 'tela-meus-cronogramas',
    standalone: true,
    imports: [HeaderSecundarioComponent, CommonModule],
    templateUrl: './cronograma.component.html',
    styleUrls: ['./cronograma.component.css'],
    providers: [EstabelecimentoService]
})
export class TelaCronogramaComponent implements OnInit {
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

    scrollCards(direction: string): void {
        const container = document.querySelector('.cards-wrapper') as HTMLElement;
        const scrollAmount = 300; 
    
        if (direction === '1') {
            container.scrollLeft += scrollAmount;
        } else if (direction === '-1') {
            container.scrollLeft -= scrollAmount;
        }
    }

    navegarEditarCronograma(id: number): void {
        if (id) {
            this.router.navigate([`/cronograma/editar/`, id]);
        } else {
            console.error("ID não encontrado");
        }
    }

    navegarEstabelecimento(id: number) {
        this.router.navigate([`/estabelecimento/`, id]);
    }
    
}   
