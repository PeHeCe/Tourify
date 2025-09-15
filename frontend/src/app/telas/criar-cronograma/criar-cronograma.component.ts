import { Component } from "@angular/core";
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { HeaderPrincipalComponent } from "../../header-principal.component";
import { LoginFormComponent } from "../../usuario/login-form.component";

@Component({
    selector: 'tela-criar-cronograma',
    standalone: true,
    imports: [RouterLink, RouterLinkActive, LoginFormComponent, HeaderPrincipalComponent],
    templateUrl: './criar-cronograma.component.html',
    styleUrl: './criar-cronograma.component.css'
})
export class TelaCriarCronogramaComponent {

    constructor(private router: Router) {}

    criarManual() {
        this.router.navigate(["/criar_cronograma/manual"])
    }

    criarAutomatico() {
        this.router.navigate(["/criar_cronograma/automatico"])
    }
}