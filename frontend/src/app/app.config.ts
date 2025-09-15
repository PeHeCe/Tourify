import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { UsuarioService } from './usuario/usuario.service';
import { EstabelecimentoService } from './estabelecimento/estabelecimento.service';
import { CronogramaService } from './cronograma/cronograma.service';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideHttpClient(), {provide: UsuarioService}, {provide: EstabelecimentoService}, {provide: CronogramaService}]
};
 