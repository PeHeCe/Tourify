import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Estabelecimento } from "./estabelecimento.model";
import { catchError, Observable, throwError } from "rxjs";

@Injectable()
export class EstabelecimentoService {
  private baseUrl = "https://localhost:7141/api";

  private httpClient = inject(HttpClient);

  getAllEstabelecimento(): Observable<Estabelecimento[]> {
    return this.httpClient.get<Estabelecimento[]>(`${this.baseUrl}/estabelecimento`).pipe(
      catchError((error) => this.errorHandler(error, "Erro ao buscar todos os estabelecimentos"))
    );
  }

  getEstabelecimentoById(id: string): Observable<Estabelecimento> {
    return this.httpClient.get<Estabelecimento>(`${this.baseUrl}/estabelecimento/${id}`).pipe(
      catchError((error) => this.errorHandler(error, `Erro ao buscar estabelecimento com ID ${id}`))
    );
  }

  buscarEstabelecimento(busca: string) {
    return this.httpClient.get<any>(`${this.baseUrl}/estabelecimento/buscar/${busca}`)
}

  atualizarEstabelecimento(estabelecimento: Estabelecimento): Observable<Estabelecimento> {
    return this.httpClient.put<Estabelecimento>(`${this.baseUrl}/estabelecimento/${estabelecimento.id}`, estabelecimento).pipe(
      catchError((error) => this.errorHandler(error, `Erro ao atualizar estabelecimento com ID ${estabelecimento.id}`))
    );
  }

  adicionarEstabelecimento(estabelecimento: Estabelecimento): Observable<Estabelecimento> {
    return this.httpClient.post<Estabelecimento>(`${this.baseUrl}/estabelecimento`, estabelecimento).pipe(
      catchError((error) => this.errorHandler(error, "Erro ao adicionar novo estabelecimento"))
    );
  }

  removerEstabelecimento(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseUrl}/estabelecimento/${id}`).pipe(
      catchError((error) => this.errorHandler(error, `Erro ao remover estabelecimento com ID ${id}`))
    );
  }

  private errorHandler(error: any, info: string): Observable<never> {
    console.error(info, error); // Loga o erro no console para depuração
    return throwError(() => ({
      info_extra: info,
      error_SS: error,
      error_CS: "Ocorreu um erro inesperado. Por favor, tente novamente.",
    }));
  }
}
