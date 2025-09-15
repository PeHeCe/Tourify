export class Cronograma {
    
    constructor(public id: number, public nome: string, public data: Date, public hora_inicio: string, public hora_fim: string, public custo_maximo?: number) {
        
    }
}