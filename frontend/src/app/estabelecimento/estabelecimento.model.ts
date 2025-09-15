export class Estabelecimento {
    constructor(
        public id: number,
        public nome: string,
        public endereco: string,
        public nivelPreco?: string,
        public horarioAbertura?: string,
        public horarioFechamento?: string,
        public telefoneContato?: string,
        public descricao?: string,
        public site?: string,
        public data?: string,
        public imagem?: string
    ) {}
}
