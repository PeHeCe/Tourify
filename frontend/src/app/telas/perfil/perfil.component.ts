import { Component, OnInit } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { HeaderPrincipalComponent } from "../../header-principal.component";
import { UsuarioService } from '../../usuario/usuario.service';
import { User } from '../../usuario/usuario.model';

@Component({
  selector: 'app-perfil',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, HeaderPrincipalComponent],
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class TelaPerfilComponent implements OnInit {
  nome: string = 'Luana Nascimento';
  email: string = 'luananascimento&#64;gmail.com';
  usuario: any

  constructor(private router: Router, private usuarioService: UsuarioService) {}

  ngOnInit(): void {
    this.usuarioService.getUserbyId(Number(localStorage.getItem("idUsuario"))).subscribe({
      next: (retorno: any) => {
        console.log(retorno)
        // console.log({_id: dadosSucesso.messageList[0]._id, content: dadosSucesso.messageList[0].content})

        this.usuario = retorno

        console.log(this.usuario)
    },
    error: (dadosErro) => {
        console.log("Erro Subscribe = ", dadosErro.info_extra)
        console.log(dadosErro)
    }
    })
  }

  editarPerfil(): void {
    console.log('Editar perfil clicado!');
  
  }
  excluirPerfil(): void {
    console.log('Excluir perfil clicado!');
  }

  navegarMeusCronogramas() {
    this.router.navigate([`/perfil/cronogramas`])
  }
}
