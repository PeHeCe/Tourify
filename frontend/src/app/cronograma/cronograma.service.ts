import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, Observable } from "rxjs";
import { Cronograma } from "./cronograma.model";

@Injectable()
export class CronogramaService {
    private baseUrl = "https://localhost:7141/api"

    private httpClient = inject(HttpClient)

    addCronograma(crono: Cronograma, idUsuario: number) {
        return this.httpClient.post<any>(`${this.baseUrl}/cronograma/manual/${idUsuario}`, crono).pipe(
            catchError((e) => this.errorHandler(e, "addCronograma()"))
        );
    }

    addCronogramaAutomatico(crono: Cronograma, idUsuario: number) {
        return this.httpClient.post<any>(`${this.baseUrl}/cronograma/automatico/${idUsuario}`, crono).pipe(
            catchError((e) => this.errorHandler(e, "addCronograma()"))
        );
    }

    addEstabelecimentoToCronograma(idCrono: number, idEstabelecimento: number) {
        return this.httpClient.get<any>(`${this.baseUrl}/cronograma/adicionar_estabelecimento/${idCrono}/${idEstabelecimento}`).pipe(
            catchError((e) => this.errorHandler(e, "addCronograma()"))
        );
    }

    getCronogramasByUsuario(idUsuario: number) {
        return this.httpClient.get<any>(`${this.baseUrl}/cronograma/${idUsuario}`).pipe(
            catchError((e) => this.errorHandler(e, "getCronograma()"))
        );
    }

    getCronogramasPublicos() {
        return this.httpClient.get<any>(`${this.baseUrl}/cronograma/publicos`).pipe(
            catchError((e) => this.errorHandler(e, "getCronograma()"))
        );
    }

    getDadosCronograma(idCronograma: number) {
        return this.httpClient.get<any>(`${this.baseUrl}/cronograma/dados/${idCronograma}`).pipe(
            catchError((e) => this.errorHandler(e, "getCronograma()"))
        );
    }

    deleteEstabelecimentoFromCronograma(id: number) {
        return this.httpClient.get<any>(`${this.baseUrl}/cronograma/remover_estabelecimento/${id}`).pipe(
            catchError((e) => this.errorHandler(e, "getCronograma()"))
        );
    }

    errorHandler(e: any, info: string): Observable<any> {
        throw({
            info_extra: info,
            error_SS: e, 
            error_CS: "Cliente-side User: Ocorreu um erro!"
        })
    }
}