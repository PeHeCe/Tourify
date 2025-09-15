import { Component, Input } from "@angular/core";

@Component({
    selector: 'app-header-secundario',
    standalone: true,
    imports: [],
    templateUrl: './header-secundario.component.html',
    styleUrl: './header-secundario.component.css'
})
export class HeaderSecundarioComponent {

    @Input() nomeTela: string = ""
}