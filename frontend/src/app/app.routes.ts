import { Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { TelaInicioComponent } from './telas/inicio/inicio.component';
import { TelaLoginComponent } from './telas/login/login.component';
import { TelaEstabelecmentoComponent } from './telas/estabelecimento/estabelecimento.component';
import { TelaCadastroComponent } from './telas/cadastro/cadastro.component';
import { TelaCriarCronogramaComponent } from './telas/criar-cronograma/criar-cronograma.component';
import { TelaCriarCronogramaManualComponent } from './telas/criar-cronograma-manual/criar-cronograma-manual.component';
import { TelaPerfilComponent } from './telas/perfil/perfil.component'; 
import { TelaMeusCronogramasComponent } from './telas/meus-cronogramas/meus-cronogramas.component';
import { TelaCronogramaComponent } from './telas/cronograma/cronograma.component';
import { TelaCriarCronogramaAutomaticoComponent } from './telas/criar-cronograma-automatico/criar-cronograma-automatico.component';
import { TelaBuscarCronogramasComponent } from './telas/buscar-cronogramas/buscar-cronogramas.component';
import { TelaAdicionarLocalComponent } from './telas/adicionar-local/adicionar-local.component';
import { TelaEditarCronogramaComponent } from './telas/editar-cronograma/editar-cronograma.component';
import { TelaBuscarEstabelecimentosComponent } from './telas/buscar-estabelecimentos/buscar-estabelecimentos.component';

export const routes: Routes = [
    { path: "", redirectTo: "/login", pathMatch: "full" },
    { path: "login", title: "Login", component: TelaLoginComponent },
    { path: "inicio", title: "Início", component: TelaInicioComponent },
    { path: "cadastro", title: "Cadastro", component: TelaCadastroComponent },
    { path: "estabelecimento/:idEstabelecimento", title: "Estabelecimento", component: TelaEstabelecmentoComponent },
    { path: "buscar_estabelecimentos", title: "Buscar Estabelecimentos", component: TelaBuscarEstabelecimentosComponent },
    { path: "buscar_cronogramas", title: "Buscar Cronogramas", component: TelaBuscarCronogramasComponent },
    { path: "criar_cronograma", title: "Criar Cronograma", component: TelaCriarCronogramaComponent },
    { path: "criar_cronograma/manual", title: "Criar Cronograma Manual", component: TelaCriarCronogramaManualComponent },
    { path: "criar_cronograma/automatico", title: "Criar Cronograma Automático", component: TelaCriarCronogramaAutomaticoComponent },
    { path: "perfil", title: "Perfil", component: TelaPerfilComponent },
    { path: "perfil/cronogramas", title: "Meus Cronogramas", component: TelaMeusCronogramasComponent },
    { path: "cronograma/:idCronograma", title: "Cronograma", component: TelaCronogramaComponent },
    { path: "cronograma/editar/:idCronograma", title: "Editar Cronograma", component: TelaEditarCronogramaComponent},
    { path: "cronograma/editar/adicionar_estabelecimento/:idCronograma", title: "Adicionar Estabelecimento", component: TelaAdicionarLocalComponent },
    // { path: "autenticacao", title: "Autenticação", component: AuthenticationComponent, children: AUTH_ROUTES}, 
    { path: "**", component: PageNotFoundComponent }
];
 
