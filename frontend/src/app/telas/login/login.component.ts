import { Component } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";
import { HeaderPrincipalComponent } from "../../header-principal.component";
import { LoginFormComponent } from "../../usuario/login-form.component";

@Component({
    selector: 'tela-login',
    standalone: true,
    imports: [RouterLink, RouterLinkActive, LoginFormComponent],
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})
export class TelaLoginComponent {

}