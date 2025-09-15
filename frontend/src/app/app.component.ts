import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderPrincipalComponent } from './header-principal.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderPrincipalComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';

}

 