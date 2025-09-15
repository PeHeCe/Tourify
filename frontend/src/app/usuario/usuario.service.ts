import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { User } from "./usuario.model";
import { catchError, Observable } from "rxjs";

@Injectable()
export class UsuarioService {
    private baseUrl = "https://localhost:7141/api"

    private httpClient = inject(HttpClient)

    addUser(user: User) {
        return this.httpClient.post<any>(`${this.baseUrl}/usuario/`, user).pipe(
            catchError((e) => this.errorHandler(e, "addUser()"))
        );
    }

    getUser(email: string, senha: string) {
        return this.httpClient.get<any>(`${this.baseUrl}/usuario/${email}/${senha}`);
    }

    getUserbyId(id: number) {
        return this.httpClient.get<any>(`${this.baseUrl}/usuario/${id}`);
    }

    errorHandler(e: any, info: string): Observable<any> {
        throw({
            info_extra: info,
            error_SS: e, 
            error_CS: "Cliente-side User: Ocorreu um erro!"
        })
    }
}