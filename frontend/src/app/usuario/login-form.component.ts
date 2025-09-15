import { Component, inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { UsuarioService } from "./usuario.service";
import { Router } from "@angular/router";

@Component({
    selector: 'user-login-form',
    standalone: true,
    imports: [ReactiveFormsModule],
    templateUrl: 'login-form.component.html',
    styleUrl: 'login-form.component.css'
})
export class LoginFormComponent implements OnInit {
    private router = inject(Router)
    private userService = inject(UsuarioService)

    erroRetorno: boolean = false;

    myForm!: FormGroup

    onSubmit() {
        console.log(this.myForm.value)

        this.userService.getUser(this.myForm.value.usuarioTS, this.myForm.value.senhaTS).subscribe(data=> {
            if (data.retorno) {
                console.log(data)
                this.erroRetorno = true
            } else {
                localStorage.setItem("idUsuario", data.id)
                localStorage.setItem("nomeUsuario", data.nome)
                
                this.router.navigate(['/inicio'])
                this.erroRetorno = false
            }
        })

        this.myForm.reset()
    }

    ngOnInit(): void {
        this.myForm = new FormGroup({
            usuarioTS: new FormControl(null, Validators.required),
            senhaTS: new FormControl(null, Validators.required),
        })
    }
}