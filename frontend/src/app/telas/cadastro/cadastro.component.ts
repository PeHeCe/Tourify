import { Component, inject, OnInit } from '@angular/core';
import { FormGroup, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import { RouterLink, Router, RouterLinkActive } from '@angular/router';
import { UsuarioService } from '../../usuario/usuario.service';
import { User } from '../../usuario/usuario.model';

@Component({
  selector: 'app-register',
  standalone:true,
  imports: [RouterLink, RouterLinkActive, ReactiveFormsModule],
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class TelaCadastroComponent implements OnInit{
  private userService = inject(UsuarioService)
  
  cadastroForm!: FormGroup;

  constructor(private router: Router) {}


  ngOnInit(): void { 
    this.cadastroForm = new FormGroup({
      id: new FormControl(0), 
      nome: new FormControl(null, Validators.required),
      sobrenome: new FormControl(null, Validators.required),
      telefone: new FormControl(null),
      cep: new FormControl(null, Validators.required),
      email: new FormControl(null, [Validators.required, Validators.email, Validators.pattern("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]),
      senha: new FormControl(null, [Validators.required, Validators.minLength(8)]),
      cpf: new FormControl(null, Validators.required)
      
    })
  }
  

  onSubmit() {
        const userAux = new User(
                                 this.cadastroForm.value.id,
                                 this.cadastroForm.value.nome, 
                                 this.cadastroForm.value.sobrenome, 
                                 this.cadastroForm.value.telefone, 
                                 this.cadastroForm.value.cep, 
                                 this.cadastroForm.value.email, 
                                 this.cadastroForm.value.senha, 
                                 this.cadastroForm.value.cpf)

        this.userService.addUser(userAux).subscribe({

            next: (dadosSucesso: any) => {
                console.log(dadosSucesso)
                alert("Usuario cadastrado com sucesso!")
                this.cadastroForm.reset()
                this.router.navigate([`/login`]);
            },
            error: (dadosErro: any) => {
                console.log(`Erro  = ${dadosErro.info_extra}`)
                alert("Erro ao cadastrar o usuario, email ou senha invalidos!")
            }
        })
        
        
    }
  }
