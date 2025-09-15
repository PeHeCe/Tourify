import { Component, inject, OnInit } from "@angular/core";
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { HeaderPrincipalComponent } from "../../header-principal.component";
import { LoginFormComponent } from "../../usuario/login-form.component";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { CronogramaService } from "../../cronograma/cronograma.service";
import { Cronograma } from "../../cronograma/cronograma.model";

@Component({
    selector: 'tela-criar-cronograma',
    standalone: true,
    imports: [ReactiveFormsModule, HeaderPrincipalComponent],
    templateUrl: './criar-cronograma-manual.component.html',
    styleUrl: './criar-cronograma-manual.component.css'
})
export class TelaCriarCronogramaManualComponent implements OnInit {
    private cronoService = inject(CronogramaService)

    myForm!: FormGroup

    constructor (private router: Router) {}

    ngOnInit(): void {
        this.myForm = new FormGroup({
            nomeTS: new FormControl(null, Validators.required),
            dataTS: new FormControl(null, Validators.required),
            horarioInicioTS: new FormControl(null, Validators.required),
            horarioFimTS: new FormControl(null, Validators.required),
        })
    }

    onSubmit() {
        console.log("aaaaaa")
        console.log(this.myForm.value)
        const cronograma = new Cronograma(0, this.myForm.value.nomeTS, this.myForm.value.dataTS, this.myForm.value.horarioInicioTS + ":00", this.myForm.value.horarioFimTS + ":00", 0)

        console.log(cronograma)

        console.log(localStorage.getItem("idUsuario"))
        console.log(localStorage.getItem("nomeUsuario"))

        this.cronoService.addCronograma(cronograma, Number(localStorage.getItem("idUsuario"))).subscribe({
            next: (dadosSucesso: any) => {
                console.log(dadosSucesso)
                // alert("Cronograma criado!\r\nPara acessá-lo entre no seu perfil e escolha a opção \"Meus Cronogramas\"")
                alert("Cronograma criado!")
                this.router.navigate(['/cronograma/' + dadosSucesso])
                
            },
            error: (dadosErro: any) => {
                console.log(`Erro  = ${dadosErro.info_extra}`)
                
            }
        })

        this.myForm.reset()
    }
}