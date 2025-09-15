import { Component } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";

@Component({
    selector: 'app-header-principal',
    standalone: true,
    imports: [RouterLink, RouterLinkActive],
    templateUrl: './header-principal.component.html',
    styleUrl: './header-principal.component.css'
})
export class HeaderPrincipalComponent {

    nomeUsuario: string = localStorage.getItem("nomeUsuario") || ""
}